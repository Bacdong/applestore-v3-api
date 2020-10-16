using System;
using System.Collections.Generic;
using System.Text;
using applestore.Application.DTOs;
using applestore.Application.Modules.Products.DTOs;

namespace applestore.Application.Modules.Products {
    public class PublicProductServices : IPublicProductServices {
        public PagedViewModel<ProductViewModel> GetAllByCategoryId(int categoryId, int pageIndex, int pageSize) {
            throw new NotImplementedException();
        }
    }
}