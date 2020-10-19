using System;

namespace applestore.Data.Entity {
    public class ProductImage {
        public int id {get; set;}
        public int productId {get; set;}
        public string imagePath {get; set;}
        public bool isDefault {get; set;}
        public DateTime created {get; set;}
        public int sortOrder {get; set;}

        public Product product {get; set;}
    }
}