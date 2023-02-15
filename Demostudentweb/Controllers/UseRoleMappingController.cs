using Demostudentweb.Core.Contract;
using Demostudentweb.Core.Domain.RequestModel;
using Demostudentweb.Infra.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demostudentweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseRoleMappingController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UseRoleMappingController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost]
        public async Task<IActionResult> Postdata(UserRoleRequestModel userRoleRequestModel)
        {
            await _userRoleService.AddUserRoleAsync(userRoleRequestModel);
            return Created("Created!", null);
        }
    }
}
