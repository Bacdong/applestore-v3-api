using Microsoft.AspNetCore.Http;

namespace applestore.APIs.Modules.Product.Serializers {
    public class ProductCreateSerializer {
        public string name {get; set;}
        public string brief {get; set;}
        public string title {get; set;}
        public decimal price {get; set;}
        public decimal originalPrice {get; set;}
        public int inventory {get; set;}
        public string slug {get; set;}
        public int languageId {get; set;}

        public IFormFile thumbnail {get; set;}
    }
}