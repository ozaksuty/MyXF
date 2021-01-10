using MyXF.Client.mobilebase.Helper;
using MyXF.Client.mobilebase.Services;
using System.Runtime.CompilerServices;

namespace MyXF.Client.mobilebase.Selectors.interfaces
{
    public interface IApiRequestSelector<T> : IServiceBase
    {
        T GetApiRequestByPriority(IApiRequest<T> apiRequest, PriorityType priorityType, [CallerMemberName] string methodName = "");
    }
}