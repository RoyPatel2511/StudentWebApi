using Demostudentweb.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demostudentweb.Infra.Contract
{
    public interface IUserRoleMapping
    {
        Task<int> AddUserRole(UserRoleMapping userRoleMapping);
    }
}
