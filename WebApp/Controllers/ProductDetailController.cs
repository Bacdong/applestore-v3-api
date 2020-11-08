using System.Threading.Tasks;
using applestore.Application.Modules.Products;
using Microsoft.AspNetCore.Mvc;


namespace applestore.WebApp.Controllers {

    [Route("frontapi/Product/{id}")]
    [ApiController]

    public class ProductDetailController : ControllerBase {

        private readonly IPublicProductServices _publicProductServices;

        public ProductDetailController(IPublicProductServices publicProductServices) {
            _publicProductServices = publicProductServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetId(int id) {
            var detail = await _publicProductServices.ProductDetailView();

            return Ok(detail);
        }
    }
}