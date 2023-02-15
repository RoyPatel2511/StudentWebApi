using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demostudentweb.Infra.Domain.Entities
{
    public class User
    {  
        User()
        {
        }

        public User(string userName, byte[] password, byte[] passwordKey)
        {
            UserName = userName;
            Password = password;
            PasswordKey = passwordKey;
        }

        public int Id { get; set; }
        
        public string UserName { get; set; }

        public byte[] Password { get; set; }
            
        public byte[] PasswordKey { get; set; }    
            
            
    }
}
