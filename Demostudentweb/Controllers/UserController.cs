using Demostudentweb.Core.Contract;
using Demostudentweb.Core.Domain.RequestModel;
using Demostudentweb.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demostudentweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        { 
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(UserRequestModel userRequestModel)
        {
            await _userService.AddUserAync(userRequestModel);
            return Created("Success!!", null);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Loginauthentication(LoginModel loginModel)
        {
            var data= await _userService.LoginUserAync(loginModel);
            return Ok(data);
        }
    }
}
 