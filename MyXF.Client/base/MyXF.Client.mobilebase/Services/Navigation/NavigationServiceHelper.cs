using MyXF.Client.mobilebase.Helper;
using MyXF.Client.mobilebase.ViewModels.Base;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyXF.Client.mobilebase.Services.Navigation
{
    public class NavigationServiceHelper
    {
        private bool animated => Device.RuntimePlatform == Device.Android ? false : true;
        protected async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType);

            await Shell.Current.Navigation.PushAsync(page, animated);

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }
        protected async Task InternalNavigateToPopupAsync(Type viewModelType, object parameter)
        {
            PopupPage page = CreatePopupPage(viewModelType);
            await PopupNavigation.Instance.PushAsync(page);
            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }
        protected async Task InternalNavigateToModalAsync(Type viewModelType, object parameter)
        {
            try
            {
                Page page = CreatePage(viewModelType);
                await Shell.Current.Navigation.PushModalAsync(page);
                await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.Namespace.Replace(GlobalSetting.Instance.ViewModelPath, GlobalSetting.Instance.PagesPath);
            viewName += $".{viewModelType.Name.Replace("ViewModel", string.Empty)}";
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }
        protected Type GetPopupPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.Namespace.Replace(GlobalSetting.Instance.ViewModelPath, GlobalSetting.Instance.ViewsPath);
            viewName += $".{viewModelType.Name.Replace("ViewModel", string.Empty)}";
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }
        protected Page CreatePage(Type viewModelType)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
                throw new Exception($"Cannot locate page type for {viewModelType}");
            try
            {
                return Activator.CreateInstance(pageType) as Page;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        protected PopupPage CreatePopupPage(Type viewModelType)
        {
            Type pageType = GetPopupPageTypeForViewModel(viewModelType);
            if (pageType == null)
                throw new Exception($"Cannot locate popup page type for {viewModelType}");
            return Activator.CreateInstance(pageType) as PopupPage;
        }
    }
}