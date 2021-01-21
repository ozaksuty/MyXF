using MyXF.Client.mobile.Endpoints.User;
using MyXF.Client.mobilebase.Helper;
using MyXF.Client.mobilebase.Selectors.interfaces;
using MyXF.Client.mobilebase.Services.AppCenter;
using Polly;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyXF.Client.mobile.Services.User
{
    public class UserService : IUserService
    {
        private readonly IApiRequest<IUserEndpoint> _request;
        private readonly IApiRequestSelector<IUserEndpoint> _apiRequestSelector;
        private readonly IAppCenterService _appCenterService;
        public UserService(IApiRequest<IUserEndpoint> request,
            IApiRequestSelector<IUserEndpoint> apiRequestSelector,
            IAppCenterService appCenterService)
        {
            _request = request;
            _request.BaseApiAddress = "https://reqres.in/api404";
            _apiRequestSelector = apiRequestSelector;
            _appCenterService = appCenterService;
        }
        public async Task<List<Models.User>> Get(PriorityType priorityType)
        {
            List<Models.User> result = null;
            Task<List<Models.User>> _task = null;

            var _api = _apiRequestSelector.GetApiRequestByPriority(_request, priorityType);
            _task = _api.Get();

            result = await Policy
              .Handle<ApiException>(_appCenterService.HandleApiException)
              .WaitAndRetryAsync(retryCount: 2, sleepDurationProvider: retryAttempt =>
              TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
              .ExecuteAsync(async () => await _task);

            return result;
        }
    }
}