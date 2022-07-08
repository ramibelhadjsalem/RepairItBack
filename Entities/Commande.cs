using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepairItBack.Entities
{
    public class Commande:BaseEntity
    {
        public String deviceType { get; set; }
        public String  Brand { get; set; }

        public String Description { get; set; }

        public float  Price { get; set; }
        [Range(0,5)]
        public int Status { get; set; }

        public int ClientId { get; set; }
        public AppUser Client { get; set; }

        public int ReparateurId { get; set; }
        public AppUser Reparateur {get;set;}

       
    }
}