using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RepairItBack.DTOs;
using RepairItBack.DTOs.Response;
using RepairItBack.Entities;

namespace RepairItBack.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterDto ,AppUser>();
            CreateMap<AppUser,UserResponse>();
            CreateMap<CommandeDto, Commande>();
            CreateMap<AppUser,ReparateurResponse>();
            CreateMap<AppUser,ReparateurWithDetailsResponse>();
            

            CreateMap<Commande,CommandeResponse>();
            
        }
    }
}