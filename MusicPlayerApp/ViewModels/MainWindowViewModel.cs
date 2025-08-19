using CommunityToolkit.Mvvm.ComponentModel;
using MusicPlayerApp.Stores;

namespace MusicPlayerApp.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        HistoryRouter<ViewModelBase>? _router;

        [ObservableProperty]
        ViewModelBase? _currentPage;

        public MainWindowViewModel()
        {
            CurrentPage = new HandleViewModel();
        }
        public MainWindowViewModel(HistoryRouter<ViewModelBase> router)
        {
            _router = router;
            _router.CurrentViewModelChanged += viewModel => CurrentPage = viewModel;
            _router.GoTo<HandleViewModel>();
        }
    }
}
