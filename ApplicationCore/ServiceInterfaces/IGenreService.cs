using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.Entities;
namespace ApplicationCore.ServiceInterfaces
{
    public interface IGenreService
    {
        Task<List<GenreModel>> GetAllGenre();
    }
}
