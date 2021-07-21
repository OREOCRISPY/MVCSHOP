using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Models;
using ApplicationCore.Entities;


namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        public UserController(IUserService UserService) {
            _UserService = UserService;
        }
        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> Purchase([FromBody] UserPurchaseRequestModel model)
        {
            var res=await _UserService.PurchaseMovie(model);
            return Ok(res);
        }
        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> Favorite([FromBody] UserFavoriteRequestModel model) {
            var res = await _UserService.FavoriteMovie(model);
            return Ok(res);
        }
        [HttpPost]
        [Route("unfavorite")]
        public async Task<IActionResult> UnFavorite([FromBody] UserFavoriteRequestModel model)
        {
            var res = await _UserService.UnFavoriteMovie(model);
            return Ok(res);
        }

        [HttpGet]
        [Route("{id:int}/movie/{movieId:int}/favorite")]
        public async Task<IActionResult> checkUserFavorite(int id,int movieId){
           var res=await _UserService.CheckUserFavorite(id, movieId);
            return Ok(res);
        }

        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> changeReview(String text,int rating,[FromBody]UserLoginRequestModel model,int movid) {
            var res = await _UserService.ModifyReview(text, rating, model, movid);
            return Ok(res);
        }
        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> PutReview(int UserId,int mId,String text,int rating, [FromBody]UserLoginRequestModel model) {
            var Review = new Review { MovieId = mId, CreatedDate = DateTime.Now, UserId =UserId,
                ReviewText = text, Rating =rating };
            var res = await _UserService.PutReview(Review, model);
            return Ok(res);
        }
        [HttpDelete]
        [Route("{userId:int}/movie/{movieId:int}")]
        public async Task<IActionResult> DeleteMovie(int UserId, int MovieId) {
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}/purchases")]
        public async Task<IActionResult> GetUserPurchase(int id) {
            var res=await _UserService.GetPurchase(id);
            return Ok(res);
        }

        [HttpGet]
        [Route("{id:int}/favorites")]
        public async Task<IActionResult> GetUserFavorite(int id)
        {
            var res = await _UserService.GetFavorite(id);
            return Ok(res);
        }

        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetUserReview(int id)
        {
            var res=await _UserService.getReview(id);
            return Ok(res);
        }


    }

}