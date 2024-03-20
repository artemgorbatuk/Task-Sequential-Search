using Api.Enhancements;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [ProducesDefaultResponseType(typeof(RequestResult<TextSourceResult>))]
        public async IAsyncEnumerable<RequestResult<TextSourceResult>> SearchAsync(string mask)
        {
            HttpContext?.Features?.Get<IHttpResponseBodyFeature>()?.DisableBuffering();

            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(30));

            await foreach (var textSource in serviceTextSource.SearchAsync(mask, cancellationTokenSource.Token))
            {
                RequestResult<TextSourceResult> result;
                try
                {
                    result = new RequestResult<TextSourceResult>()
                    {
                        Data = textSource,
                        MessageType = MessageType.Success,
                        MessageText = $"{textSource.Id} was successfully obtained"
                    };
                }
                catch (Exception exception)
                {
                    result = new RequestResult<TextSourceResult>()
                    {
                        Data = textSource,
                        MessageType = MessageType.Error,
                        MessageText = exception.Message
                    };
                }
                yield return result;
            }
        }
    }
}