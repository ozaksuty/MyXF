using MyXF.Client.mobile.Endpoints.User;
using MyXF.Client.mobilebase.Helper;
using MyXF.Client.mobilebase.Selectors.interfaces;
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
        public UserService(IApiRequest<IUserEndpoint> request,
            IApiRequestSelector<IUserEndpoint> apiRequestSelector)
        {
            _request = request;
            _apiRequestSelector = apiRequestSelector;
        }
        public async Task<List<Models.User>> Get(PriorityType priorityType)
        {
            List<Models.User> result = null;
            Task<List<Models.User>> _task = null;
            Exception exception = null;

            try
            {
                var _api = _apiRequestSelector.GetApiRequestByPriority(_request, priorityType);
                _task = _api.Get();
                result = await Policy
                          .Handle<ApiException>()
                          .WaitAndRetryAsync(retryCount: 2, sleepDurationProvider: retryAttempt =>
                          TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                          .ExecuteAsync(async () => await _task);
            }
            catch (ApiException apiException)
            {
                exception = apiException;
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return result;
        }
    }
}