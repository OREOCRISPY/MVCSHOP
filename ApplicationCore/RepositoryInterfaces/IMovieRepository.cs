using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository: IAsyncRepository<Movie>
    {
      Task<List<Movie>>  GetHighest30GrossingMovies();
        // 10 methods
        Task<List<Movie>> Get30MoviesByGenre(int Genre_id);
        Task<Movie> GetTopRatedMovie();
        Task<List<Review>> GetReviewByMovieId(int id);
    }
}
