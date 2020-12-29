using MyXF.Client.mobile.ViewModels;
using MyXF.Client.mobilebase.Helper;
using MyXF.Client.mobilebase.ViewModels.Base;
using System.Reflection;
using Xamarin.Forms;

namespace MyXF.Client.mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            GlobalSetting.Instance.PagesPath = "Pages";
            GlobalSetting.Instance.ViewsPath = "Views";
            GlobalSetting.Instance.ViewModelPath = "ViewModels";
            GlobalSetting.Instance.BaseEndpoint = "https://jsonplaceholder.typicode.com";
            ViewModelLocator.Init<AppShellPageViewModel> (Assembly.GetExecutingAssembly());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
