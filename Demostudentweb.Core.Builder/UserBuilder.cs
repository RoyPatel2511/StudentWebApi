using Demostudentweb.Core.Domain.RequestModel;
using Demostudentweb.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demostudentweb.Core.Builder
{
    public class UserBuilder
    {
        public static User Build(UserRequestModel Model,byte[] password,byte[] passwordKey )
        {
            return new User(Model.UserName, password,passwordKey);
        }
    }
}
