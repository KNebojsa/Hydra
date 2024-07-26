using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hydra.WebApi.Data;
using Hydra.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Hydra.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(DataContext context) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            var users = context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            var user = context.Users.Find(id);
            if(user==null)
            {
                return NotFound(user);
            }

            return Ok(user);
        }
    }
}