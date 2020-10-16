using System;
using System.Collections.Generic;
using System.Text;
using applestore.Data.Enum;

namespace applestore.Data.Entity {
    public class Order {
        public int id {get; set;}
        public DateTime created {get; set;}
        public Guid userId {get; set;}
        public string shippingName {get; set;}
        public string shippingAddress {get; set;}
        public string shippingEmail {get; set;}
        public string shippingPhone {get; set;}
        public OrderStatus status {get; set;}

        public List<OrderLine> orderLines {get; set;}

        public Auth auth {get; set;}
    }
}