using ClockNx.ViewModel;

namespace ClockNx;

public partial class TimerPage : ContentPage
{
	public TimerPage(TimerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}

