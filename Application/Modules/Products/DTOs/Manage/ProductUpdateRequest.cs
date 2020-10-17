namespace applestore.Application.Modules.Products.DTOs.Manage {
    public class ProductUpdateRequest {
        public int id {get; set;}
        public string name {get; set;}
        public string brief {get; set;}
        public string title {get; set;}
        public int languageId {get; set;}
        public string seoAlias {get; set;}
    }
}