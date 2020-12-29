using MyXF.Client.mobilebase.Helper;
using MyXF.Client.mobilebase.Selectors.interfaces;

namespace MyXF.Client.mobilebase.Selectors.implementations
{
    public class ApiRequestSelector<T> : IApiRequestSelector<T>
    {
        public T GetApiRequestByPriority(IApiRequest<T> apiRequest, PriorityType priorityType)
        {
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