using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Models;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<List<Movie>> GetMoviesByEmail(string email)
        {
            var Userid = await _dbContext.Users.Where(n => n.Email == email).FirstOrDefaultAsync();
            var UserPurchases = await _dbContext.Purchases.Include(m => m.Movie).Include(m=>m.Movie.Genres).Where(n => n.UserId == Userid.Id).ToListAsync();
            var Movies = new List<Movie>();
            foreach (var UserPurchase in UserPurchases) {
                Movies.Add(UserPurchase.Movie);
            }
            return Movies;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<Purchase> PurchaseMovie(UserPurchaseRequestModel model)
        {
            var movie=_dbContext.Purchases.Where(m => m.MovieId == model.MovieId).Where(m => m.UserId == model.UserId).FirstAsync();
            if (movie != null) {
                throw new Exception($"{model.Email} already bought {model.MovieId}");
            }
            var price = await _dbContext.Movies.Where(m => m.Id == model.MovieId).Select(m => m.Price).FirstOrDefaultAsync();
            if (price == null) {
                throw new Exception($"No Movie Found with {model.MovieId}");
            }
            var purchase = new Purchase
            {
                MovieId = model.MovieId,
                PurchaseDateTime = DateTime.Now,
                TotalPrice = (decimal)price,
                UserId = model.UserId,
                PurchaseNumber = Guid.NewGuid()
                
            };
            var res= await _dbContext.Purchases.AddAsync(purchase);
            return purchase;
        }

        public async Task<String> UnFavorite(UserFavoriteRequestModel model)
        {
            var Favorite = new Favorite { MovieId = model.MovieId, UserId = model.UserId };
            var res=await _dbContext.Favorites.AddAsync(Favorite);
            return "success";
        }

        public async Task<String> Favorite(UserFavoriteRequestModel model)
        {
            var Favorite = new Favorite { MovieId = model.MovieId, UserId = model.UserId };
            var res = _dbContext.Favorites.Remove(Favorite);
            await _dbContext.SaveChangesAsync();
            return "success";
        }

        public async Task<string> CheckFavorite(int id, int MovieId)
        {
            var res=await _dbContext.Favorites.Where(m => m.UserId == id).Where(m => m.MovieId == MovieId).FirstAsync();
            return res==null?"false":"true";
        }

        public async Task<Review> GetReview(int userid, int MovieId)
        {
            var res = await _dbContext.Reviews.Where(m => m.UserId == userid).Where(n=>n.MovieId== MovieId).FirstAsync();
            return res;
        }

        public async Task<Review> PutReview(Review review, int UserId)
        {
            var cur = await _dbContext.Reviews.Where(m => m.MovieId == review.MovieId).Where(m => m.UserId == UserId).FirstAsync();
            if (cur == null) {
                await _dbContext.Reviews.AddAsync(review);
                return review;
            }
            cur.Rating = review.Rating;
            cur.ReviewText = review.ReviewText;
            _dbContext.SaveChanges();
            return cur;
        }

        public async Task<List<ReviewModel>> GetReviews(int UserId)
        {
            var res = await _dbContext.Reviews.Where(m => m.UserId == UserId).ToListAsync();
            if (res == null) {
                throw new Exception("user does not have any review");
            }
            var model = new List<ReviewModel>();
            foreach (var r in res) {
                var temp = new ReviewModel { CreatedDate = r.CreatedDate, MovieId = r.MovieId, Rating = r.Rating, ReviewText = r.ReviewText, UserId = r.UserId };
                model.Add(temp);
            }
            return model;
        }

        public async Task<List<Favorite>> GetFavorites(int UserId) {
            var res = await _dbContext.Favorites.Where(m => m.UserId == UserId).ToListAsync();
            return res;
        }

        public async Task<List<Movie>> RepositoryGetPurchase(int uid)
        {
;            var res = await _dbContext.Purchases.Include(m => m.Movie).Where(m => m.UserId == uid).Select(m => m.Movie).ToListAsync();
            return res;
            
        }
    }
}