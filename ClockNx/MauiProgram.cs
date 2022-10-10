using ClockNx.ViewModel;
using Microsoft.Maui.LifecycleEvents;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif


namespace ClockNx;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.ConfigureLifecycleEvents( events => {
#if WINDOWS
				events.AddWindows(windows => windows
						.OnClosed((window, args) =>
						{
							var g = Globals.GetGlobals();
							var clientSize = g.ActualClientSize;
							if (clientSize.Height != window.Bounds.Height || clientSize.Width != window.Bounds.Width)
							{ // save size
								Preferences.Default.Set("Height", window.Bounds.Height);
								Preferences.Default.Set("Width", window.Bounds.Width);
							}
						})
						.OnWindowCreated(window => {
							window.SizeChanged += OnSizeChanged;							
						})
						);
#endif
            });

		builder.Services.AddSingleton<TimerPage>();
		builder.Services.AddSingleton<TimerViewModel>();
		return builder.Build();
	}
#if WINDOWS
        static void OnSizeChanged(object sender, Microsoft.UI.Xaml.WindowSizeChangedEventArgs args)
        {
            ILifecycleEventService service = MauiWinUIApplication.Current.Services.GetRequiredService<ILifecycleEventService>();
            service.InvokeEvents(nameof(Microsoft.UI.Xaml.Window.SizeChanged));
        }
#endif
}
