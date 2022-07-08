using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepairItBack.Data;
using RepairItBack.DTOs;
using RepairItBack.DTOs.Response;
using RepairItBack.Entities;
using RepairItBack.Helpers;
using RepairItBack.Interfaces;

namespace RepairItBack.Services
{
    public class ReparateurService : IReparateurService
    
    {   
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReparateurService(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PageList<ReparateurResponse>> findAllReparateur(PaginationParams paginationParams)
        {
            var query = _userManager.Users
                            .Where(u => u.UserRoles.Any(r => r.Role.Name == "Reparateur"))
                            .ProjectTo<ReparateurResponse>(_mapper.ConfigurationProvider)
                            .AsQueryable();
            query  = query.OrderByDescending(x=>x.Rating);

            return await PageList<ReparateurResponse>.CreateAsync(
                            query,
                            paginationParams.PageNumber,
                            paginationParams.PageSize
                            );
        }

        public async Task<IEnumerable<ReparateurResponse>> findBest4()
        {
           var roleUsers = await _userManager.Users.Where(u => u.UserRoles.Any(r => r.Role.Name == "Reparateur"))
                            .OrderByDescending(x=>x.Rating)
                            .Take(4)
                            .ProjectTo<ReparateurResponse>(_mapper.ConfigurationProvider)
                            .ToListAsync();
            return roleUsers;
        }

        public async Task<AppUser> findReparateurById(int id)
        {
           return await _userManager.Users  
                        .Where(u => u.UserRoles.Any(r => r.Role.Name == "Reparateur"))
                        .FirstOrDefaultAsync(x=>x.Id ==id);
        }
    }
}