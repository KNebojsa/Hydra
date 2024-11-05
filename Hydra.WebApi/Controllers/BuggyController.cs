using Hydra.WebApi.Data;
using Hydra.WebApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.WebApi.Controllers
{
    public class BuggyController (DataContext context) : BasicApiController
    {
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetAuth()
        {
            return "secret text";
        }


        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNoFound()
        {
            var thing = context.Users.Find(-1);

            if (thing == null) return NotFound();

            return thing;
        }

        [HttpGet("server-error")]
        public ActionResult<AppUser> GetServerError()
        {
            var thing = context.Users.Find(-1) ?? throw new Exception("A bad thing has happend"); ;

            return thing;
        }

        [HttpGet("bad-request")]
        public ActionResult<AppUser> GetServerGetBadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
}
