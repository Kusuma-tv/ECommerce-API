using ECommerce.Entity.User;
using ECommerce.Entity.User.ECommerce.Entity.User;
using ECommerce.Interfaces.IBAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserBAL _userBAL;

        public UserController(IUserBAL userBAL)
        {
            _userBAL = userBAL;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        
        public async Task<IActionResult> Register(UserRequest request)
        {
            var response =
                await _userBAL.RegisterAsync(request);

            return StatusCode(
                response.StatusCode,
                response);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _userBAL.LoginAsync(request);

            return StatusCode(response.StatusCode, response);
        }
    }
}