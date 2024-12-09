using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hydra.WebApi.Entities;

namespace Hydra.WebApi.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}