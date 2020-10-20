using System.Threading.Tasks;
using applestore.ViewModels.Core;
using applestore.ViewModels.Modules.Product;
using applestore.ViewModels.Modules.Product.Manage;

namespace applestore.Application.Modules.Products {
    public interface IManageProductServices {
        Task<int> create(ProductCreateRequest request);

        Task<int> update(ProductUpdateRequest request);

        Task<int> delete(int productId);

        Task<bool> updatePrice(int productId, decimal newPrice);

        Task<bool> updateStock(int productId, int newQuantity);

        Task addViewCount(int productId);

        Task<PagedResult<ProductViewModel>> GetProductAllPaging(GetProductPagingRequest request);
    }
}