using System.Collections.Generic;
using System.Threading.Tasks;
using applestore.Application.DTOs;
using applestore.Application.Modules.Products.DTOs;
using applestore.Application.Modules.Products.DTOs.Public;

namespace applestore.Application.Modules.Products {
    public interface IPublicProductServices {
        PagedResult<ProductViewModel> GetAllByCategoryId(GetProductPagingRequest request); 
        Task<List<ProductViewModel>> GetAll();
    }
}