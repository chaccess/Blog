using Main.Auth.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Authentication.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(ILogger<AuthController> logger, IAuthService authService) : ControllerBase
    {
        private readonly ILogger<AuthController> _logger = logger;
        private readonly IAuthService _authService = authService;


        [HttpPost(Name = "Login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest model)
        {
            await HttpContext.AuthenticateAsync();
            var response = await _authService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
