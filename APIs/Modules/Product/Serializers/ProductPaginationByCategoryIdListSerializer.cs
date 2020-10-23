using applestore.APIs.Core;

namespace applestore.APIs.Modules.Product.Serializers {
    public class ProductPaginationByCategoryIdListSerializer : PaginationBaseSerializer {
        public int? categoryId {get; set;}
    }
}