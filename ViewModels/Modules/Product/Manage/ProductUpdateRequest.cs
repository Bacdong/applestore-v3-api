using Microsoft.AspNetCore.Http;

namespace applestore.ViewModels.Modules.Product.Manage {
    public class ProductUpdateRequest {
        public int id {get; set;}
        public string name {get; set;}
        public string brief {get; set;}
        public string title {get; set;}
        public int languageId {get; set;}
        public string seoAlias {get; set;}

        public IFormFile thumbnail {get; set;}
    }
}