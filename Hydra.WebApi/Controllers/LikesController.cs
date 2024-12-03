using Hydra.WebApi.DTOs;
using Hydra.WebApi.Entities;
using Hydra.WebApi.Extensions;
using Hydra.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.WebApi.Controllers
{
    public class LikesController(ILikesRepository likesRepository) : BasicApiController
    {
        [HttpPost("{targetUserId:int}")]
        public async Task<ActionResult> AddLike(int targetUserId)
        {
            var sourceUserId = User.GetUserId();

            if (sourceUserId == targetUserId) return BadRequest("You cannot like yourself");

            var existingLike = await likesRepository.GetUserLike(sourceUserId, targetUserId);
            if (existingLike == null)
            {
                var like = new UserLike
                {
                    SourceUserId = sourceUserId,
                    TargetUserId = targetUserId
                };

                likesRepository.AddLike(like);
            }
            else
            {
                likesRepository.DeleteLike(existingLike);
            }

            if (await likesRepository.SaveChanges())
                return Ok();

            return BadRequest("Failed to like user");
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<int>>> GetCurrentUserLikeIds()
        {
            return Ok(await likesRepository.GetCurrentUserLikeIds(User.GetUserId()));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUserLikes(string predicate)
        {
            var users = await likesRepository.GetUserLikes(predicate, User.GetUserId());
            return Ok(users);  
        }
    }
}
