using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieCardResponseModel>> GetTopRevenueMovies()
        {
            var movies = await _movieRepository.GetHighest30GrossingMovies();

            var movieCards = new List<MovieCardResponseModel>();

            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel{  Id = movie.Id, Budget =   movie.Budget.GetValueOrDefault(), PosterUrl = movie.PosterUrl,Title = movie.Title});
            }

            return movieCards;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            var movieDetails = new MovieDetailsResponseModel()
            {
                 Id = movie.Id, Title = movie.Title, Budget = movie.Budget.GetValueOrDefault(), PosterUrl=movie.PosterUrl,
                 Price=movie.Price, ReleaseDate=movie.ReleaseDate, Overview=movie.Overview, Tagline=movie.Tagline,
                Rating=movie.Rating
            };

            movieDetails.Casts = new List<CastResponseModel>();

            foreach (var cast in movie.MovieCasts)
            {
                movieDetails.Casts.Add(new CastResponseModel
                {
                    Id = cast.CastId, Name = cast.Cast.Name, Character = cast.Character, ProfilePath = cast.Cast.ProfilePath
                });
            }

            movieDetails.Genres = new List<GenreModel>();
            foreach (var genre in movie.Genres)
            {
                movieDetails.Genres.Add( 
                    new GenreModel
                    {
                        Id = genre.Id, Name = genre.Name
                    }
                    );
            }

            return movieDetails;
        }

        public async Task<List<MovieCardResponseModel>> GetMovieCardByGenre(int Genre_id)
        {
            var movies=await _movieRepository.Get30MoviesByGenre(Genre_id);

            var MovieCardResponse = new List<MovieCardResponseModel>();

            foreach (var movie in movies) {
                var genre = new List<GenreModel>();
                foreach (var g in movie.Genres) {
                    genre.Add(new GenreModel { Id=g.Id,Name=g.Name});
                }
                MovieCardResponse.Add(new MovieCardResponseModel() {
                    Id = movie.Id,
                    Budget = movie.Budget.GetValueOrDefault(),
                    PosterUrl = movie.PosterUrl,
                    Title = movie.Title,
                    Genres=genre
                });
            }
            return MovieCardResponse;
        }

        public async Task<int> getCountMovie()
        {
            int res=await _movieRepository.GetCountAsync();
            return res;
        }

        public async Task<ApplicationCore.Entities.Movie> GetTopRated()
        {
            var res = await _movieRepository.GetTopRatedMovie();
            return res;
        }

        public async Task<List<ReviewModel>> GetReviewByMovieId(int id)
        {
            var res = await _movieRepository.GetReviewByMovieId(id);
            var Movie = new List<ReviewModel>();
            foreach (var r in res) {
                var model = new ReviewModel { CreatedDate = r.CreatedDate, Rating = r.Rating, ReviewText = r.ReviewText, MovieId = r.MovieId, UserId = r.UserId };
                Movie.Add(model);
            }
            return Movie;
        }
    }

}

