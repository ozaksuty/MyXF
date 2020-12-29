using MyXF.Client.mobilebase.Helper;
using MyXF.Client.mobilebase.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyXF.Client.mobile.Services.User
{
    public interface IUserService : IServiceBase
    {
        Task<List<Models.User>> Get(PriorityType priorityType);
    }
}