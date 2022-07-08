using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepairItBack.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; } 

        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public bool Enable { get; set; } = true;
    }
}