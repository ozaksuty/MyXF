using Refit;
using System;
using System.Collections.Generic;

namespace MyXF.Client.mobilebase.Services.AppCenter
{
    public interface IAppCenterService : IServiceBase
    {
        void Init();
        bool HandleApiException(ApiException ex);
        void HandleException(Exception ex);
        void Log(string name, IDictionary<string, string> properties = null);
    }
}