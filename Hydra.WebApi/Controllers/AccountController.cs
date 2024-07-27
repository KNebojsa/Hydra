using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Hydra.WebApi.Data;
using Hydra.WebApi.DTOs;
using Hydra.WebApi.Entities;
using Hydra.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hydra.WebApi.Controllers
{
    public class AccountController(DataContext context, ITokenService tokenService) : BasicApiController
    {
        [HttpPost("register")] //account/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExist(registerDto.Username))
                return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();

            var user = new AppUser()
            {
                Username = registerDto.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return new UserDto
            {
                Username = user.Username,
                Token = tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == loginDto.Username.ToLower());

            if (user == null) return Unauthorized("Invalid UserName");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDto
            {
                Username = user.Username,
                Token = tokenService.CreateToken(user)
            };
        }
        public async Task<bool> UserExist(string username)
        {
            return await context.Users.AnyAsync(x => x.Username.ToLower() == username.ToLower());
        }
    }
}