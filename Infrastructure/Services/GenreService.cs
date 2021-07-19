using System;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class GenreService:IGenreService
    {
        public readonly IGenreRepository _IGenreRepository;
        public GenreService(IGenreRepository GenreRepository)
        {
            _IGenreRepository = GenreRepository;
        }

        public async Task<List<GenreModel>> GetAllGenre()
        {
            var Genres = await _IGenreRepository.GetAllGenreInfo();
            var AllGenres = new List<GenreModel>();
            foreach (var Genre in Genres) {
                AllGenres.Add(new GenreModel() {Id=Genre.Id,Name=Genre.Name});
            }
            return AllGenres;
        }
    }
}
