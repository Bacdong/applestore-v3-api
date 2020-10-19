using System.Collections.Generic;
using applestore.Application.DTOs;

namespace applestore.Application.Modules.Products.DTOs.Manage {
    public class GetProductPagingRequest : PagingRequestBase {
        public string keyword {get; set;}
        public List<int> categoryIds {get; set;}
    }
}