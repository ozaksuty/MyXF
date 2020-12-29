using MyXF.Client.mobilebase.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyXF.Client.mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }

        public ICommand DialogCommand => new Command(() =>
        {
            DialogService.AlertAsync("Dialog Service", "Test", "Ok");
        });
        public ICommand GoToListPageCommand => new Command(() =>
        {
            NavigationService.NavigateToAsync<ListPageViewModel>();
        });
    }
}