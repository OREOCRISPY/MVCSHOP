using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.Entities;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
      Task<List<MovieCardResponseModel>> GetTopRevenueMovies();

       Task<MovieDetailsResponseModel> GetMovieDetails(int id);

        Task<List<MovieCardResponseModel>> GetMovieCardByGenre(int Genre_id);

        Task<int> getCountMovie();

        Task<Movie> GetTopRated();

        Task<List<ReviewModel>> GetReviewByMovieId(int id);
    }
}
