using Refit;
using System;

namespace MyXF.Client.mobilebase.Services.AppCenter
{
    public interface IAppCenterService : IServiceBase
    {
        void Init();
        bool HandleApiException(ApiException ex);
        void HandleException(Exception ex);
    }
}