using IdentityService.Api.Application.Models;
using System.Threading.Tasks;

namespace IdentityService.Api.Application.Services
{
    public interface IIdentityService
    {
        Task<LoginResponseModel> Login(LoginRequestModel requestModel);
    }
}
