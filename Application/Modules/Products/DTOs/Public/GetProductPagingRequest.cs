using System.Collections.Generic;
using applestore.Application.DTOs;

namespace applestore.Application.Modules.Products.DTOs.Public {
    public class GetProductPagingRequest : PagingRequestBase {
        public int? categoryId {get; set;}
    }
}