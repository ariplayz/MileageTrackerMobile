using CommunityToolkit.Mvvm.ComponentModel;

namespace MileageTrackerMobile.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public bool loginScreen = true;

}