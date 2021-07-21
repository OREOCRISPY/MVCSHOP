using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using ApplicationCore.ServiceInterfaces;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {

        private readonly ICastService _CastService;

        public CastController(ICastService CastService) {
            _CastService = CastService;
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetCast")]
        public async Task<IActionResult> GetCastById(int id) {
            var cast = await _CastService.GetCastById(id);
            if (cast == null) {
                return NotFound("Cast with this ID does not exist in Our database");
            }
            return Ok(cast);
        }
        
    }
}