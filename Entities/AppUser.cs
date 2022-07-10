using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace RepairItBack.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public DateTime DateOf { get; set; }
        public DateTime CreatedAt { get; set; } = new DateTime();
        
        public String  FirstName { get; set; }
        public String  LastName { get; set; }   
        public float  Rating { get; set; }
        public String Tasks {get; set;}
        public String description { get; set; }
        public float AddressLong { get; set; }
        public float AddressLarg { get; set; }
        public String CinFileUrl { get; set; }
        public String MFFileUrl { get; set; }
     
        
        public bool Verifed { get; set; }

        public ICollection<AppUserRole> UserRoles { get; set; }
    
        public ICollection<Commande> CommandeClient {get;set;}
        public ICollection<Commande> CommandeReparateur {get;set;}


    
    
    }
   
}