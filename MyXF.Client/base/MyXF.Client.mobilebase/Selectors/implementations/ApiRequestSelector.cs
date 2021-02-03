using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MyXF.Client.mobilebase.Helper;
using MyXF.Client.mobilebase.Selectors.interfaces;
using MyXF.Client.mobilebase.Services.AppCenter;

namespace MyXF.Client.mobilebase.Selectors.implementations
{
    public class ApiRequestSelector<T> : IApiRequestSelector<T>
    {
        private readonly IAppCenterService _appCenterService;
        public ApiRequestSelector(IAppCenterService appCenterService)
        {
            _appCenterService = appCenterService;
        }
        public T GetApiRequestByPriority(IApiRequest<T> apiRequest, PriorityType priorityType, [CallerMemberName] string methodName = "")
        {
            _appCenterService.Log(methodName,
                new Dictionary<string, string>
                {
                    {
                        "Time", DateTime.Now.ToString()
                    }
                });

            switch (priorityType)
            {
                case PriorityType.Speculative:
                    return apiRequest.Speculative;
                case PriorityType.UserInitiated:
                    return apiRequest.UserInitiated;
                case PriorityType.Background:
                    return apiRequest.Background;
                default:
                    return apiRequest.UserInitiated;
            }
        }
    }
}