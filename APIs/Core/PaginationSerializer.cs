using System.Collections.Generic;

namespace applestore.APIs.Core {
    public class PaginationSerializer<T> {
        public List<T> Items {get; set;}
        public int totalRecord {get; set;}
    }
}