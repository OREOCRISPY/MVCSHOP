using System;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _CastRepository;
        public CastService(ICastRepository castRepository) {
            _CastRepository = castRepository;
        }

        public async Task<CastModel> GetCastById(int id)
        {
            var cast= await _CastRepository.GetByIdAsync(id);
            var res = new CastModel
            {
                Gender = cast.Gender,
                Id = cast.Id,
                Name = cast.Name,
                ProfilePath = cast.ProfilePath,
                TmdbUrl = cast.TmdbUrl
            };
            return res;
        }
    }
}
