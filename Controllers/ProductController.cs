using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace applestore.Controllers {

    [Route("frontapi/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> Get() {
            return Ok("Test success!");
        }
    }
}