using System;
using System.Collections.Generic;
using System.Text;

namespace applestore.Application.Modules.Products.DTOs {
    public class ProductCreateRequest {
        public string name {get; set;}
        public decimal price {get; set;}
    }
}