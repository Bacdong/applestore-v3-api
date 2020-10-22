using System.Collections.Generic;
using System.Threading.Tasks;
using applestore.ViewModels.Core;
using applestore.ViewModels.Modules.Product;
using applestore.ViewModels.Modules.Product.Manage;
using Microsoft.AspNetCore.Http;

namespace applestore.Application.Modules.Products {
    public interface IManageProductServices {
        Task<int> create(ProductCreateRequest request);

        Task<int> update(ProductUpdateRequest request);

        Task<int> delete(int productId);

        Task<bool> updatePrice(int productId, decimal newPrice);

        Task<bool> updateStock(int productId, int newQuantity);

        Task addViewCount(int productId);

        Task<int> AddImages(int productId, List<IFormFile> files);

        Task<int> UpdateImages(int imageId, bool isDefault);

        Task<int> RemoveImages(int imageId);

        Task<List<ProductImageViewModel>> GetListImage(int productId);

        Task<PagedResult<ProductViewModel>> GetProductAllPaging(
            ViewModels.Modules.Product.Manage.GetProductPagingRequest request);
    }
}