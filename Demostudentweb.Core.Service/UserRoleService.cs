using Demostudentweb.Core.Builder;
using Demostudentweb.Core.Contract;
using Demostudentweb.Core.Domain.Exception;
using Demostudentweb.Core.Domain.RequestModel;
using Demostudentweb.Infra.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demostudentweb.Core.Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleMapping _userRoleMapping;

        public UserRoleService(IUserRoleMapping userRoleMapping)
        {
            _userRoleMapping = userRoleMapping;
        }

        public async Task AddUserRoleAsync(UserRoleRequestModel userRoleRequestModel)
        {
            try
            {
                var data = UserRoleMappingBuilder.Build(userRoleRequestModel);
                var count = await _userRoleMapping.AddUserRole(data);
                if (count == 0)
                {
                    throw new BadRequestException("Student is not created succssfully.");
                }
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}
