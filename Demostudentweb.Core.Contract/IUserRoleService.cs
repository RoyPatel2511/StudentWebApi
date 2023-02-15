using Demostudentweb.Core.Domain.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demostudentweb.Core.Contract
{
    public interface IUserRoleService
    {
        Task AddUserRoleAsync(UserRoleRequestModel userRoleRequestModel);
    }
}
