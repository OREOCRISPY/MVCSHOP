using System;
using ApplicationCore.Models;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using System.Collections.Generic;
namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel requestModel);

        Task<UserLoginResponseModel> Login(string email, string password);

        Task<UserEditProfileResponseModel> Edit(UserEditProfileRequest requestModel);

        Task<UserResponseModel> GetUserById(int id);

        Task<List<MovieCardResponseModel>> MyMovie(String email);

        Task<int> GetUserCount();

        Task<UserPurchaseResponseModel> PurchaseMovie(UserPurchaseRequestModel mod);

        Task<String> FavoriteMovie(UserFavoriteRequestModel model);
        Task<String> UnFavoriteMovie(UserFavoriteRequestModel model);
        Task<String> CheckUserFavorite(int id, int MovieId);

        Task<Review> ModifyReview(String text, int rating, UserLoginRequestModel model,int movieId);
        Task<Review> PutReview(Review review, UserLoginRequestModel model);
        Task<List<ReviewModel>> getReview(int id);
        Task<List<Favorite>> GetFavorite(int id);
        Task<List<Movie>> GetPurchase(int uid);
    }

}
