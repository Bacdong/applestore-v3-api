using System.Threading.Tasks;
using applestore.APIs.Modules.Product.Serializers;
using applestore.Application.Modules.Products;
using Microsoft.AspNetCore.Mvc;

namespace applestore.WebApp.Controllers {

    [Route("frontapi/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {
        private readonly IPublicProductServices _publicProductServices;
        private readonly IManageProductServices _manageProductServices;
        public ProductController(
            IPublicProductServices publicProductServices,
            IManageProductServices manageProductServices) {

            _publicProductServices = publicProductServices;
            _manageProductServices = manageProductServices;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get() {
            var products = await _publicProductServices.ProductListView();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int productId) {
            var product = await _manageProductServices.GetProductById(productId);
            if (product == null)
                return BadRequest("Cannot find product, try again!");

            return Ok(product);
        }

        [HttpGet("category")]
        public async Task<IActionResult> Get([FromQuery]ProductPaginationByCategoryIdListSerializer request) {
            var products = await _publicProductServices.CategoryListByIdView(request);

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> create([FromBody]ProductCreateSerializer request) {
            var productId = await _manageProductServices.create(request);
            if (productId == 0)
                return BadRequest();

            var product = await _manageProductServices.GetProductById(productId);

            return Created(nameof(GetProductById), product);
        }
    }
}