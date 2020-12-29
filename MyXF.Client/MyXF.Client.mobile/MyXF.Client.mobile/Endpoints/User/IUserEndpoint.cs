using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyXF.Client.mobile.Endpoints.User
{
    [Headers("Content-Type : application/json")]
    public interface IUserEndpoint
    {
        [Get("/users")]
        Task<List<Models.User>> Get();
    }
}