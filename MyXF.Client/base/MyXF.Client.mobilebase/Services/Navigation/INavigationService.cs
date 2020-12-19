using MyXF.Client.mobilebase.ViewModels.Base;
using System.Threading.Tasks;

namespace MyXF.Client.mobilebase.Services.Navigation
{
    public interface INavigationService : IServiceBase
    {
        ViewModelBase PreviousPageViewModel { get; }
        Task InitializeAsync<TViewModel>() where TViewModel : ViewModelBase;
        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;
        Task NavigateToModalAsync<TViewModel>() where TViewModel : ViewModelBase;
        Task NavigateToModalAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;
        Task NavigatePopAsync();
        Task NavigatePopModalAsync();
        Task NavigateToPopupAsync<TViewModel>() where TViewModel : ViewModelBase;
        Task NavigateToPopupAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;
        Task RemovePopupAsync();
        Task RemoveLastFromBackStackAsync();
        Task RemoveBackStackAsync(bool includeLastPage = false);
        Task SetMainPageAsync<TViewModel>(bool wrapInNavigationPage = true, object parameter = null) where TViewModel : ViewModelBase;
        void SetShellCurrentTabItem(int index);
    }
}
