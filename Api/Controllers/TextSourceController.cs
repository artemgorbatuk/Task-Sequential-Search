using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextSourceController : ControllerBase
    {
        public TextSourceController()
        {
            
        }

        [HttpPost]
        public void Search()
        {
        }
    }
}