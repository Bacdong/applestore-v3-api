using System;
using System.Collections.Generic;
using System.Text;
using applestore.Data.Enum;

namespace applestore.Data.Entity {
    public class Promotion {
        public int id {get; set;}
        public string name {get; set;}
        public DateTime startTime {get; set;}
        public DateTime endTime {get; set;}
        public bool applyForAll {get; set;}
        public int? discountPercent {get; set;}
        public decimal discountAmount {get; set;}
        public string productIds {get; set;}
        public string ProductCategoryIds {get; set;}
        public Status status {get; set;}
    }
}