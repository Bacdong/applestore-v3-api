using Microsoft.AspNetCore.Http;

namespace applestore.APIs.Modules.Product.Serializers {
    public class ProductUpdateSerializer {
        public int id {get; set;}
        public string name {get; set;}
        public string brief {get; set;}
        public string title {get; set;}
        public int languageId {get; set;}
        public string slug {get; set;}

        public IFormFile thumbnail {get; set;}
    }
}