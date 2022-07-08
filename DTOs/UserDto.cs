using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairItBack.DTOs
{
    public class UserDto
    {
      

        public int id { get; set; }
        public string Username { get; set; }
        public ICollection<String> Roles { get; set; }
        public string Token { get; set; }


        public UserDto(int id, string username, ICollection<String> roles, string token)
        {
            this.id = id;
            Username = username;
            Token = token;
            Roles = roles;
        }

    }
}