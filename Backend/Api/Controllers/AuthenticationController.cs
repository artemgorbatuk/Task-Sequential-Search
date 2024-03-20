using Api.Enhancements;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceAuthentification serviceAuthentification;
        private readonly ILogger<AuthenticationController> logger;

        public AuthenticationController(IServiceAuthentification serviceAuthentification, ILogger<AuthenticationController> logger)
        {
            this.serviceAuthentification = serviceAuthentification;
            this.logger = logger;
        }

        [HttpPost("Login")]
        [ProducesDefaultResponseType(typeof(RequestResult<bool>))]
        public IActionResult Login([FromBody]LoginFilter filter)
        {
            bool isAuthenticated = serviceAuthentification.Login(filter.UserName, filter.Password);

            return isAuthenticated 
                ? Ok(new RequestResult<bool>()
                {
                    Data = true,
                    MessageType = MessageType.Success,
                    MessageText = "Successfuly authentificated"
                })
                : Unauthorized(new RequestResult<bool>()
                {
                    Data = false,
                    MessageType = MessageType.Warning,
                    MessageText = "Authentication failed"
                });
        }
    }
}