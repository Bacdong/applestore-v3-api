using System.Collections.Generic;
using System.Threading.Tasks;
using applestore.ViewModels.Core;
using applestore.ViewModels.Modules.Product;
using applestore.ViewModels.Modules.Product.Public;

namespace applestore.Application.Modules.Products {
    public interface IPublicProductServices {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request); 
    }
}