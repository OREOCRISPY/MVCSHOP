using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
      Task<List<MovieCardResponseModel>> GetTopRevenueMovies();

       Task<MovieDetailsResponseModel> GetMovieDetails(int id);

        Task<List<MovieCardResponseModel>> GetMovieCardByGenre(int Genre_id);
    }
}
