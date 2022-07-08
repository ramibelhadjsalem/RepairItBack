using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepairItBack.DTOs
{
    public class RegisterDto
    {
       
        [Required]
        public String  FirstName { get; set; }
         [Required]
        public String  LastName { get; set; }
        [Required]
        public String  Email { get; set; }
       
        [Required]
        public String  Password { get; set; }
      
        public RegisterDto(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

      

       
    }
}