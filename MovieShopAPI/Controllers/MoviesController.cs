using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.ServiceInterfaces;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetTopRevenueMovies();

            if (!movies.Any())
            {
                return NotFound("No Movies Found");
            }

            return Ok(movies);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);

            if (movie == null)
            {
                return NotFound($"No Movie Found for that {id}");
            }
            return Ok(movie);
        }

        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopRatedMovie() {
            var res=await _movieService.GetTopRated();
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetCountMovie() {
            var res = await _movieService.getCountMovie();
            return Ok(res);
        }

        [HttpGet]
        [Route("genre/{genreid:int}")]
        public async Task<IActionResult> GetMovieByGenreId(int genreid) {
            var res = await _movieService.GetMovieCardByGenre(genreid);
            return Ok(res);
        }

        [HttpGet]
        [Route("{id:int}/review")]
        public async Task<IActionResult> GetReviewByMovieId(int id) {
            var res = await _movieService.GetReviewByMovieId(id);
            if (res == null) {
                return NotFound("No one leave reviews to this movie or movie does not exist");
            }
            return Ok(res);
        }
    }
}