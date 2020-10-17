using applestore.Data.Enum;

namespace applestore.Data.Entity {
    public class Contact {
        public int id {get; set;}
        public string name {get; set;}
        public string email {get; set;}
        public string phone {get; set;}
        public string message {get; set;}
        public Status status {get; set;}
    }
}