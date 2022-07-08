using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepairItBack.DTOs
{
    public class CommandeDto
    {
        


        [Required] public String deviceType { get; set; }
        [Required] public String Brand { get; set; }
        [Required] public String Description { get; set; }
        [Required] public int ReparateurId { get; set; }

       

    }
}