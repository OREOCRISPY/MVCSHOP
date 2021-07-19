using System;
using ApplicationCore.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IGenreRepository:IAsyncRepository<Genre>
    {
        Task<List<Genre>> GetAllGenreInfo();
    }
}
