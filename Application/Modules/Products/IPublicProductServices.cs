using System;
using System.Collections.Generic;
using System.Text;
using applestore.Application.DTOs;
using applestore.Application.Modules.Products.DTOs;

namespace applestore.Application.Modules.Products {
    public interface IPublicProductServices {
        PagedViewModel<ProductViewModel> GetAllByCategoryId(int categoryId, int pageIndex, int pageSize); 
    }
}