using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextSourceController : ControllerBase
    {
        private readonly IServiceTextSource serviceTextSource;
        private readonly ILogger<AuthenticationController> logger;

        public TextSourceController(IServiceTextSource serviceTextSource, ILogger<AuthenticationController> logger)
        {
            this.serviceTextSource = serviceTextSource;
            this.logger = logger;
        }

        [HttpPost]
        public void Search()
        {
        }
    }
}