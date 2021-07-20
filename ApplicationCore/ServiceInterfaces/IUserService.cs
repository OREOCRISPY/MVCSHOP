using System;
using ApplicationCore.Models;
using System.Threading.Tasks;
namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel requestModel);

        Task<UserLoginResponseModel> Login(string email, string password);

        Task<UserEditProfileResponseModel> Edit(UserEditProfileRequest requestModel);
    }

}
