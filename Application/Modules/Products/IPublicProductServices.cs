using System.Collections.Generic;
using System.Threading.Tasks;
using applestore.APIs.Core;
using applestore.APIs.Modules.Product.Serializers;

namespace applestore.Application.Modules.Products {
    public interface IPublicProductServices {
        Task<PaginationSerializer<ProductSerializer>> CategoryListByIdView(
            ProductPaginationByCategoryIdListSerializer request); 

        Task<List<ProductSerializer>> ProductListView();
    }
}