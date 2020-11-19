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

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId, int languageId) {
            var product = await _manageProductServices.GetProductById(productId, languageId);
            if (product == null)
                return BadRequest("Cannot find product, try again!");

            return Ok(product);
        }

        [HttpGet("category/{productId}")]
        public async Task<IActionResult> Get([FromQuery]ProductPaginationByCategoryIdListSerializer request) {
            var products = await _publicProductServices.CategoryListByIdView(request);

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> create([FromForm]ProductCreateSerializer request) {
            var productId = await _manageProductServices.create(request);
            if (productId == 0)
                return BadRequest();

            var product = await _manageProductServices.GetProductById(productId, request.languageId);

            return Created(nameof(GetProductById), product);
        }

        [HttpPut]
        public async Task<IActionResult> update([FromBody]ProductUpdateSerializer request) {
            var affectedResult = await _manageProductServices.update(request);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> delete(int productId) {
            var affectedResult = await _manageProductServices.delete(productId);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }

        [HttpPut("price/{productId}/{newPrice}")]
        public async Task<IActionResult> PriceUpdate([FromQuery]int productId, decimal newPrice) {
            var isSuccess = await _manageProductServices.PriceUpdate(productId, newPrice);
            if (isSuccess)
                return Ok();

            return BadRequest("Update failed, try again!");
        }
    }
}