using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hydra.WebApi.Data;
using Hydra.WebApi.DTOs;
using Hydra.WebApi.Entities;
using Hydra.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Hydra.WebApi.Controllers
{
    [Authorize]
    public class UsersController(IUserRepository _userRepository, IMapper _mapper) : BasicApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            return Ok(await _userRepository.GetMembersAsync());
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            var user = await _userRepository.GetMemberAsync(username);

            if (user == null)
                return NotFound(user);

            return Ok(_mapper.Map<MemberDto>(user));
        }

        [HttpPut("{username}")]
        public async Task<ActionResult> UpdateMember(string username, MemberDto updateMemberDto)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null) return NotFound();

            var x = _mapper.Map(updateMemberDto, user);
            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }
    }
}