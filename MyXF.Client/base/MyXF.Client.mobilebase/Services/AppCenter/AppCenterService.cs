using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using MyXF.Client.mobilebase.Helper;
using System;
using System.Text;

namespace MyXF.Client.mobilebase.Services.AppCenter
{
    public class AppCenterService : IAppCenterService
    {
        public void Init()
        {
            StringBuilder _appCenterBuild = new StringBuilder();
            if (!String.IsNullOrEmpty(GlobalSetting.Instance.AppCenterAndroidKey))
                _appCenterBuild.Append($"android={GlobalSetting.Instance.AppCenterAndroidKey}");
            if (!String.IsNullOrEmpty(GlobalSetting.Instance.AppCenteriOSKey))
                _appCenterBuild.Append($"ios={GlobalSetting.Instance.AppCenteriOSKey}");
            if (!String.IsNullOrEmpty(GlobalSetting.Instance.AppCenterUWPKey))
                _appCenterBuild.Append($"uwp={GlobalSetting.Instance.AppCenterUWPKey}");

            if (String.IsNullOrEmpty(_appCenterBuild.ToString()))
                throw new Exception("You have to set AppCenter secret key");

            if (!GlobalSetting.Instance.IsTest)
                Distribute.CheckForUpdate();

            Microsoft.AppCenter.AppCenter.Start(_appCenterBuild.ToString(),
              typeof(Analytics), typeof(Crashes), typeof(Distribute));
        }
    }
}