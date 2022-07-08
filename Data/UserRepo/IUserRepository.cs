using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepairItBack.Entities;

namespace RepairItBack.Data.UserRepo
{
    public interface IUserRepository
    {
       
        Task<AppUser> getByid(int id);
        void Update(AppUser user);
        Task<AppUser> getByName(String name);
        Task<IEnumerable<AppUser>> getAll();
   
    }
}