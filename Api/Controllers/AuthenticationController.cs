using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

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

        [HttpPost]
        public void Login()
        {
        }
    }
}