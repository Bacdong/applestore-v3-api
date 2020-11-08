using System;

namespace applestore.Data.Entity {
    public class Cart {
        public int id {get; set;}
        public int productId {get; set;}
        public int quantity {get; set;}
        public decimal price {get; set;}

        public Guid userId {get; set;}

        public Product product {get; set;}

        public DateTime created {get; set;}

        public DateTime updated {get; set;}

        public Auth auth {get; set;}
    }
}