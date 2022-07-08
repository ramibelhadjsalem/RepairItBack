using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RepairItBack.DTOs.Response;
using RepairItBack.Entities;
using RepairItBack.Helpers;

namespace RepairItBack.Data.ComandeRepo
{
    public class CommandeRepository:ICommandeRepository
    {     
        private readonly DataContext _context;
        public IMapper _mapper { get; }
        public CommandeRepository(DataContext context, IMapper mapper )
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddCommande(Commande commande)
        {
           await _context.Commandes.AddAsync(commande);
        }

        public async Task deleteById(int id)
        {
            var commande = await _context.Commandes.FindAsync(id);
            if(commande !=null){
                commande.DeletedAt=DateTime.Now.ToUniversalTime();
                commande.Enable = false;
                
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PageList<Commande>> findAll(PaginationParams paginationParams)
        {   var query = _context.Commandes.AsQueryable();
            query = query.OrderByDescending(x=>x.CreatedAt);
            

            return await PageList<Commande>.CreateAsync(
                query.AsNoTracking(),
                paginationParams.PageNumber,
                paginationParams.PageSize
            );
        }

        public async Task<IEnumerable<CommandeResponse>> findOuwn(int UserId)
        {
           return await _context.Commandes
                            .Where(x=> x.ClientId==UserId||x.ReparateurId==UserId)
                             .ProjectTo<CommandeResponse>(_mapper.ConfigurationProvider)
                            .ToListAsync();
        }

        public async Task<Commande> getById(int id)
        {
           return await _context.Commandes
                            .FindAsync(id);
        }
    }
}