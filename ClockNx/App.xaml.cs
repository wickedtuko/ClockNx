#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

namespace ClockNx;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
#if WINDOWS
            var mauiWindow = handler.VirtualView;
            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
            WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
            AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            var width = Preferences.Default.ContainsKey("Width") ? Preferences.Default.Get("Width", 500.0) : 500.0;
            var height = Preferences.Default.ContainsKey("Height") ? Preferences.Default.Get("Height", 500.0) : 500.0;
            var size = new SizeInt32();
            size.Height = (Int32)height;
            size.Width = (Int32)width;
            appWindow.Resize(size);
            var clientSize = appWindow.ClientSize;
            var g = Globals.GetGlobals();
            g.ActualClientSize = clientSize;
#endif
        });

        MainPage = new AppShell();
	}
}
