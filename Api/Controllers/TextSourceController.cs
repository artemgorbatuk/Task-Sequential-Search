using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;

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
        [HttpGet]
        public async IAsyncEnumerable<TextSourceResult> Search(string mask)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(30));

            await foreach (var result in serviceTextSource.SearchAsync(mask))
            {
                yield return result;
            }
        }
    }
}