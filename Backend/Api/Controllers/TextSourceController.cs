using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;

namespace Api.Controllers
{
    [Route("[controller]")]
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
        [HttpGet("Search")]
        public async IAsyncEnumerable<ActionResult<TextSourceResult>> SearchAsync(string mask)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(30));

            await foreach (var textSource in serviceTextSource.SearchAsync(mask, cancellationTokenSource.Token))
            {
                yield return Ok(textSource);
            }
        }
    }
}