using System;
using System.Collections.Generic;
using System.Text;

namespace applestore.Data.Entity {
    public class ProductInCategory {
        public int productId {get; set;}
        public Product product {get; set;}
        public int categoryId {get; set;}
        public Category category {get; set;}
    }
}