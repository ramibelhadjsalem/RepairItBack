using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepairItBack.Data.UserRepo;
using RepairItBack.DTOs;
using RepairItBack.Entities;

namespace RepairItBack.Data
{
    public class UserRepository : IUserRepository
    {   
        private readonly DataContext _context;
         private readonly IMapper _mapper;
        public UserRepository(DataContext context , IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppUser>> getAll()
        {
          return await _context.Users.ToListAsync();
        }

        public async  Task< AppUser> getByid(int id)
        {
           return await _context.Users.FindAsync(id);
        }

    

        public async Task<AppUser> getByName(string name)
        {
           return await _context.Users.SingleOrDefaultAsync(x=> x.UserName==name);
        }

        public void Update(AppUser user)
        {
           _context.Entry(user).State= EntityState.Modified;
        }

        // public async Task<IEnumerable<UserResponse>> findAllReparateur(){
        //     return await _context.Users 
        //                 .Include(x=>x.UserRoles)
        //                 .Where()
        // }
    }
}