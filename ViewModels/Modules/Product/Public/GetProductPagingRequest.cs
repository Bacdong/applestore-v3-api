using applestore.ViewModels.Core;

namespace applestore.ViewModels.Modules.Product.Public {
    public class GetProductPagingRequest : PagingRequestBase {
        public int? categoryId {get; set;}
    }
}