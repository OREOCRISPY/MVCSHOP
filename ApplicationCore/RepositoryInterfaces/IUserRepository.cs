using System;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System.Collections.Generic;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IUserRepository:IAsyncRepository<User>
    {
        Task<User> GetUserByEmail(string email);
        Task<List<Movie>> GetMoviesByEmail(String email);
        Task<Purchase> PurchaseMovie(UserPurchaseRequestModel model);
        Task<String> Favorite(UserFavoriteRequestModel model);
        Task<String> UnFavorite(UserFavoriteRequestModel model);
        Task<String> CheckFavorite(int id, int MovieId);
        Task<Review> GetReview(int userid, int MovieId);
        Task<List<ReviewModel>> GetReviews(int UserId);
        Task<Review> PutReview(Review review, int UserId);
        Task<List<Favorite>> GetFavorites(int UserId);
        Task<List<Movie>> RepositoryGetPurchase(int uid);
    }
}
