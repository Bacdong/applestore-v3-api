using System.Collections.Generic;
using System.Threading.Tasks;
using applestore.APIs.Core;
using applestore.APIs.Modules.Product.Serializers;
using Microsoft.AspNetCore.Http;

namespace applestore.Application.Modules.Products {
    public interface IManageProductServices {
        Task<int> create(ProductCreateSerializer request);

        Task<int> update(ProductUpdateSerializer request);

        Task<int> delete(int productId);

        Task<bool> PriceUpdate(int productId, decimal newPrice);

        Task<bool> InventoryUpdate(int productId, int newQuantity);

        Task addViewCount(int productId);

        Task<int> AddImages(int productId, List<IFormFile> files);

        Task<int> UpdateImages(int imageId, bool isDefault);

        Task<int> RemoveImages(int imageId);

        Task<ProductSerializer> GetProductById(int productId);

        Task<List<ProductImageViewModel>> GetListImage(int productId);

        Task<PaginationSerializer<ProductSerializer>> ProductPaginationListView(
            APIs.Modules.Product.Serializers.ProductPaginationListSerializer request);
    }
}