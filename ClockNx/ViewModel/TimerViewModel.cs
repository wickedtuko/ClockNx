using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ClockNx.ViewModel
{
    public partial class TimerViewModel : ObservableObject
    {
        [RelayCommand]
        async Task Add()
        {
            await Shell.Current.DisplayAlert("Uh oh!", "Add clicked", "OK");
        }
    }
}
