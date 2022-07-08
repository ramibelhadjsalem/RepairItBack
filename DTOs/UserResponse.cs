using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairItBack.DTOs
{
    public class UserResponse
    {   
        public int Id { get; set; }
        public String  UserName { get; set; }
        public String  Email { get; set; }
        public String  PhoneNumber { get; set; }
        public String description { get; set; }

        public UserResponse(string userName, string email, string phoneNumber, string description)
        {
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            this.description = description;
        }
    }
}