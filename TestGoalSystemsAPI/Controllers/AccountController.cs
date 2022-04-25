using Microsoft.AspNetCore.Mvc;
using TestGoalSystems.Application.Contrats.Identity;
using TestGoalSystems.Application.Models.Identity;

namespace TestGoalSystemsAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// User authentication
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
        {
            return Ok(await _authService.Login(request));
        }

        /// <summary>
        /// User registration
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
        {
            return Ok(await _authService.Register(request));
        }

    }
}
