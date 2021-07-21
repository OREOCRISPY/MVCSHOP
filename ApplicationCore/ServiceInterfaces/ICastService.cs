using System;
using ApplicationCore.Models;
using System.Threading.Tasks;
namespace ApplicationCore.ServiceInterfaces
{
    public interface ICastService
    {
        Task<CastModel> GetCastById(int id);
    }
}
