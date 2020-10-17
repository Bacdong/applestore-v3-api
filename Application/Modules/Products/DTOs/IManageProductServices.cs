using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using applestore.Application.DTOs;
using applestore.Application.Modules.Products.DTOs;
using applestore.Application.Modules.Products.DTOs.Manage;
using applestore.Application.Modules.Products.DTOs.Public;

namespace applestore.Application.Modules.Products {
    public interface IManageProductServices {
        Task<int> create(ProductCreateRequest request);

        Task<int> update(ProductUpdateRequest request);

        Task<int> delete(int productId);

        Task<bool> updatePrice(int productId, decimal newPrice);

        Task<bool> updateStock(int productId, int newQuantity);

        Task addViewCount(int productId);

        Task<List<ProductViewModel>> GetAll();
        Task<PagedResult<ProductViewModel>> GetProductAllPaging(GetProductPagingRequest request);
    }
}