using Microsoft.AspNetCore.Mvc;

namespace Maiguard.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccessCodeController : ControllerBase
    {
        private readonly string _message = "This feature is yet to be implemented. Contributions to the development of this feature are welcome at https://github.com/olumuyiwa-agboola/maiguard-api";

        [HttpPost]
        [Route("Generate")]
        public IActionResult GenerateAccessCode()
        {
            return Ok(new
            {
                message = _message
            });
        }

        [HttpPost]
        [Route("Verify")]
        public IActionResult VerifyAccessCode()
        {
            return Ok(new
            {
                message = _message
            });
        }

        [HttpDelete]
        [Route("Cancel")]
        public IActionResult CancelAccessCode()
        {
            return Ok(new
            {
                message = _message
            });
        }
    }
}
