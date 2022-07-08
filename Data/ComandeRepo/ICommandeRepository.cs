using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepairItBack.DTOs.Response;
using RepairItBack.Entities;
using RepairItBack.Helpers;

namespace RepairItBack.Data.ComandeRepo
{
    public interface ICommandeRepository
    {
        Task<PageList<Commande>> findAll(PaginationParams paginationParams);
        Task<IEnumerable<CommandeResponse>> findOuwn(int UserId);

        Task<Commande> getById(int id);
        Task deleteById(int id);
        Task AddCommande(Commande commande);

        
    }
}