using Demostudentweb.Infra.Contract;
using Demostudentweb.Infra.Domain;
using Demostudentweb.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demostudentweb.Infra.Repository
{
    public class UserRoleMappingRepository:IUserRoleMapping
    {
        private readonly DemostudentwebContext _studentwebcontext;

        public UserRoleMappingRepository(DemostudentwebContext studentwebcontext )
        { 
            _studentwebcontext = studentwebcontext;
        }

        public async Task<int> AddUserRole(UserRoleMapping userRoleMapping)
        {
            await _studentwebcontext.roleMappings.AddAsync(userRoleMapping);
            return await _studentwebcontext.SaveChangesAsync();

        }
    }
}
