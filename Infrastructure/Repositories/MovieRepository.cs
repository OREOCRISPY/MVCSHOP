using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<List<Movie>> GetHighest30GrossingMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _dbContext.Movies.Include(m => m.MovieCasts).ThenInclude(m => m.Cast)
                .Include(m => m.Genres).FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                throw new Exception($"No Movie Found with {id}");
            }

            var movieRating = await _dbContext.Reviews.Where(m => m.MovieId == id).AverageAsync(r => r == null ? 0 : r.Rating);

            if (movieRating > 0)
            {
                movie.Rating = Math.Round(movieRating, 1, MidpointRounding.AwayFromZero);
            }

            return movie;
        }

        public async Task<List<Movie>> Get30MoviesByGenre(int Genre_id)
        {
            var movieGenre = await _dbContext.Movies.Where(m=>m.Genres.Select(x=>x.Id).Contains(Genre_id)).Include(m=>m.Genres).OrderByDescending(m=>m.Revenue).Take(30).ToListAsync();
            
            return movieGenre;
        }

        public async Task<Movie> GetTopRatedMovie()
        {
            var res =await (from e in _dbContext.Movies
                       join r in _dbContext.Reviews
                       on e.Id equals r.MovieId
                       select new
                       {
                           id = e.Id,
                           Rating = r.Rating,
                           title = e.Title,
                           PosterUrl = e.PosterUrl,
                           Overview = e.Overview
                       } into g
                       group g by new { g.id, g.Overview, g.PosterUrl, g.title } into g2
                       select new
                       {
                           g2.Key.id,
                           g2.Key.Overview,
                           g2.Key.PosterUrl,
                           g2.Key.title,
                           AvgRating = g2.Average(g => g.Rating)
                       }).OrderByDescending(m => m.AvgRating).FirstOrDefaultAsync();
            var movie = new Movie { Id = res.id, Title = res.title, PosterUrl = res.PosterUrl, Overview = res.Overview, Rating = res.AvgRating };
            return movie;
        }


        public async Task<List<Review>> GetReviewByMovieId(int id)
        {
            return await _dbContext.Reviews.Where(r => r.MovieId == id).ToListAsync();
        }
    }
}
