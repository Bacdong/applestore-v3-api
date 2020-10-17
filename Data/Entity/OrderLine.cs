namespace applestore.Data.Entity {
    public class OrderLine {
        public int orderId {get; set;}
        public int productId {get; set;}
        public int quantity {get; set;}
        public decimal price {get; set;}

        public Order order {get; set;}
        public Product product {get; set;}
    }
}