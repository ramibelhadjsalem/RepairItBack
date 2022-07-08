using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairItBack.DTOs.Response
{
    public class ReparateurResponse
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public float Rating { get; set; }
        public bool Verified { get; set; }
        public String Tasks { get; set; }

        
    }
}