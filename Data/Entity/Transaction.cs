using System;
using System.Collections.Generic;
using System.Text;
using applestore.Data.Enum;

namespace applestore.Data.Entity {
    public class Transaction {
        public int id {get; set;}
        public DateTime created {get; set;}
        public string externalTransactionId {get; set;}
        public decimal amount {get; set;}
        public decimal fee {get; set;}
        public string result {get; set;}
        public string message {get; set;}
        public TransactionStatus status {get; set;}
        public string provider {get; set;}
    }
}