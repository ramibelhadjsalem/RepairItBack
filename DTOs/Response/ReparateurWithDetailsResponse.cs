using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairItBack.DTOs.Response
{
    public class ReparateurWithDetailsResponse
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String  FirstName { get; set; }
        public String  LastName { get; set; } 
        public String Email { get; set; }
        public String PhotoUrl { get; set; }
        public float  Rating { get; set; }
        public String Tasks {get; set;}
        public String description { get; set; }
        public bool Verifed { get; set; } = false;

    }
}