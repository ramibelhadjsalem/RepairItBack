using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepairItBack.Entities;

namespace RepairItBack.DTOs.Response
{
    public class CommandeResponse
    {
        public int Id { get; set; }
        public String deviceType { get; set; }
        public String  Brand { get; set; }
        public String Description { get; set; }
        public float  Price { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ReparateurResponse Reparateur {get;set;}
    }
}