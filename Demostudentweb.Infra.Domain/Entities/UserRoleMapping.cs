using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demostudentweb.Infra.Domain.Entities
{
    public class UserRoleMapping
    {
        public UserRoleMapping(int userId, int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public int Id { get; set; }

        public int RoleId { get; set; } 

        public Role Role { get; set; } 
        
        public int UserId { get; set; }

        public User User { get; set; } 
    }
}
