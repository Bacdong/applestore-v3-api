using Microsoft.AspNetCore.Http;

namespace applestore.ViewModels.Modules.Product.Manage {
    public class ProductCreateRequest {
        public string name {get; set;}
        public string brief {get; set;}
        public string title {get; set;}
        public decimal price {get; set;}
        public decimal originalPrice {get; set;}
        public int stock {get; set;}
        public string seoAlias {get; set;}
        public int languageId {get; set;}

        public IFormFile thumbnail {get; set;}
    }
}