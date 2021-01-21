using MyXF.Client.mobilebase.Services.AppCenter;
using MyXF.Client.mobilebase.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyXF.Client.mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IAppCenterService _appCenterService;

        public MainPageViewModel(IAppCenterService appCenterService)
        {
            _appCenterService = appCenterService;
        }

        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }

        public ICommand DialogCommand => new Command(() =>
        {
            try
            {
                throw new Exception("Test Exception");
            }
            catch (Exception ex)
            {
                _appCenterService.HandleException(ex);
            }
            //DialogService.AlertAsync("Dialog Service", "Test", "Ok");
        });
        public ICommand GoToListPageCommand => new Command(() =>
        {
            NavigationService.NavigateToAsync<ListPageViewModel>();
        });
    }
}