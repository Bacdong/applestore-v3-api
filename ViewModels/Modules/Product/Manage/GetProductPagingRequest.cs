using System.Collections.Generic;
using applestore.ViewModels.Core;

namespace applestore.ViewModels.Modules.Product.Manage {
    public class GetProductPagingRequest : PagingRequestBase {
        public string keyword {get; set;}
        public List<int> categoryIds {get; set;}
    }
}