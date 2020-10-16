using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using applestore.Application.DTOs;
using applestore.Application.Modules.Products.DTOs;

namespace applestore.Application.Modules.Products {
    public interface IManageProductServices {
        Task<int> create(ProductCreateRequest request);

        Task<int> update(ProductEditRequest request);

        Task<int> delete(int productId);

        Task<List<ProductViewModel>> GetAll();
        Task<PagedViewModel<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize);
    }
}