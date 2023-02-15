using Demostudentweb.Core.Domain.RequestModel;
using Demostudentweb.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demostudentweb.Core.Builder
{
    public class UserRoleMappingBuilder
    {
        public static UserRoleMapping Build(UserRoleRequestModel Model)
        {
            return new UserRoleMapping(Model.UserId, Model.RoleId);
        }
    }
}
