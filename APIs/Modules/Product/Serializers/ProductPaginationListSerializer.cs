using System.Collections.Generic;
using applestore.APIs.Core;

namespace applestore.APIs.Modules.Product.Serializers {
    public class ProductPaginationListSerializer : PaginationBaseSerializer {
        public string keyword {get; set;}
        public List<int> categoryIds {get; set;}
    }
}