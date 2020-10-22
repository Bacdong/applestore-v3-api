using System.Threading.Tasks;
using applestore.Application.Modules.Products;
using Microsoft.AspNetCore.Mvc;

namespace applestore.WebApp.Controllers {

    [Route("frontapi/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {
        private readonly IPublicProductServices _publicProductServices;
        public ProductController(IPublicProductServices publicProductServices) {
            _publicProductServices = publicProductServices;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get() {
            var products = await _publicProductServices.GetAll();

            return Ok(products);
        }
    }
}