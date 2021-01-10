using Microsoft.AppCenter.Analytics;
using MyXF.Client.mobilebase.Helper;
using MyXF.Client.mobilebase.Selectors.interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MyXF.Client.mobilebase.Selectors.implementations
{
    public class ApiRequestSelector<T> : IApiRequestSelector<T>
    {
        public T GetApiRequestByPriority(IApiRequest<T> apiRequest, PriorityType priorityType, [CallerMemberName] string methodName = "")
        {
            Analytics.TrackEvent($"CallerMemberName: {methodName}",
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