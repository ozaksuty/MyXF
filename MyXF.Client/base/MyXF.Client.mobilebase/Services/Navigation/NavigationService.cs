using MyXF.Client.mobilebase.ViewModels.Base;
using Rg.Plugins.Popup.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyXF.Client.mobilebase.Services.Navigation
{
    public class NavigationService : NavigationServiceHelper, INavigationService
    {
        private bool animated => Device.RuntimePlatform == Device.Android ? false : true;
        public ViewModelBase PreviousPageViewModel
        {
            get
            {
                var stack = Shell.Current.Navigation.NavigationStack;
                var viewModel = stack[stack.Count - 2].BindingContext;
                return viewModel as ViewModelBase;
            }
        }
        public Task InitializeAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return SetMainPageAsync<TViewModel>(true, null);
        }
        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }
        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }
        public Task NavigateToModalAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToModalAsync(typeof(TViewModel), null);
        }
        public Task NavigateToModalAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToModalAsync(typeof(TViewModel), parameter);
        }
        public async Task NavigatePopAsync()
        {
            await Shell.Current.Navigation.PopAsync(animated);
        }
        public async Task NavigatePopModalAsync()
        {
            if (Shell.Current.Navigation.ModalStack.Count > 0)
                await Shell.Current.Navigation.PopModalAsync();
        }
        public Task NavigateToPopupAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToPopupAsync(typeof(TViewModel), null);
        }
        public Task NavigateToPopupAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToPopupAsync(typeof(TViewModel), parameter);
        }
        public Task RemovePopupAsync()
        {
            try
            {
                if (PopupNavigation.Instance.PopupStack.Count > 0)
                {
                    PopupNavigation.Instance.PopAsync(animated);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return Task.FromResult(true);
        }
        public Task RemoveLastFromBackStackAsync()
        {
            var stack = Shell.Current.Navigation.NavigationStack;
            Shell.Current.Navigation.RemovePage(stack[stack.Count - 2]);
            return Task.FromResult(true);
        }
        public Task RemoveBackStackAsync(bool includeLastPage = false)
        {
            var stack = Shell.Current.Navigation.NavigationStack;

            var count = includeLastPage ? 0 : 1;
            for (int i = 0; i < stack.Count - count; i++)
            {
                var page = stack[i];
                Shell.Current.Navigation.RemovePage(page);
            }

            return Task.FromResult(true);
        }
        public async Task SetMainPageAsync<TViewModel>(bool wrapInNavigationPage, object parameter) where TViewModel : ViewModelBase
        {
            Page page = CreatePage(typeof(TViewModel));
            Shell.SetNavBarIsVisible(page, wrapInNavigationPage);
            Application.Current.MainPage = page;
            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }
        public void SetShellCurrentTabItem(int index)
        {
            if (Shell.Current.CurrentItem.Items.Count >= index)
                Shell.Current.CurrentItem.CurrentItem = Shell.Current.CurrentItem.Items[index];
        }
    }
}