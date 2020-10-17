using System;

namespace applestore.Application.Modules.Products.DTOs
{
    public class ProductViewModel {
        public int id {get; set;}
        public string name {get; set;}
        public string brief {get; set;}
        public string title {get; set;}
        public decimal price {get; set;}
        public decimal originalPrice {get; set;}
        public int stock {get; set;}
        public int viewCount {get; set;}
        public DateTime created {get; set;}
        public string seoAlias {get; set;}
        public int languageId {get; set;}
    }
}