using System;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
namespace Infrastructure.Repositories
{
    public class CastRepository:EfRepository<Cast>,ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext) {
        }

    }
}
