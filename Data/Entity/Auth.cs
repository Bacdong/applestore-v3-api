using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace applestore.Data.Entity {
    public class Auth : IdentityUser<Guid> {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }

        public List<Cart> carts {get; set;}
        public List<Order> orders {get; set;}
        public List<Transaction> transactions {get; set;}
    }
}