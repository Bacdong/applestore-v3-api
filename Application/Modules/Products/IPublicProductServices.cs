using System.Collections.Generic;
using System.Threading.Tasks;
using applestore.APIs.Core;
using applestore.APIs.Modules.Product.Serializers;

namespace applestore.Application.Modules.Products {
    public interface IPublicProductServices {
        Task<PaginationSerializer<ProductListSerializer>> CategoryListByIdView(
            ProductPaginationByCategoryIdListSerializer request); 

        Task<List<ProductListSerializer>> ProductListView();
    }
}