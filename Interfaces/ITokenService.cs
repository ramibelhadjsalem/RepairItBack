using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepairItBack.Entities;

namespace RepairItBack.Interfaces
{
    public interface ITokenService
    {
        Task<String> CreateToken(AppUser appUser);
    }
}