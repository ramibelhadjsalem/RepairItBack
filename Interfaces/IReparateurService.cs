using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepairItBack.DTOs;
using RepairItBack.DTOs.Response;
using RepairItBack.Entities;
using RepairItBack.Helpers;

namespace RepairItBack.Interfaces
{
    public interface IReparateurService
    {
        Task<PageList<ReparateurResponse>> findAllReparateur(PaginationParams paginationParams);
        Task<IEnumerable<ReparateurResponse>> findBest4();
        Task<AppUser> findReparateurById(int id);
    }
}