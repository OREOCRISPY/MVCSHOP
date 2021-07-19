using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenreRepository:EfRepository<Genre>,IGenreRepository
    {
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext) {
        }
        public async Task<List<Genre>> GetAllGenreInfo()
        {
            var Genres = await _dbContext.Genres.OrderBy(m => m.Id).ToListAsync();
            return Genres;
        }
     }
}
