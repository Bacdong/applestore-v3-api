using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using applestore.Application.DTOs;
using applestore.Application.Modules.Products.DTOs;
using applestore.Application.Modules.Products.DTOs.Public;

namespace applestore.Application.Modules.Products {
    public class PublicProductServices : IPublicProductServices {
        public Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public PagedResult<ProductViewModel> GetAllByCategoryId(GetProductPagingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}