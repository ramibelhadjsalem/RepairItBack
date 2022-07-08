using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepairItBack.Data.ComandeRepo;
using RepairItBack.Data.UserRepo;

namespace RepairItBack.Data
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository {get; }
        ICommandeRepository commandeRepository {get;}
        Task<bool> Complete();
        bool HasChanges();
    }
}