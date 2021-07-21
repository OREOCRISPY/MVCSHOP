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
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _GenreService;
        public GenresController(IGenreService GenreService) {
            _GenreService = GenreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres() {
            var Genres=await _GenreService.GetAllGenre();
            return Ok(Genres);
        }
    }
}