using System;
using System.Collections.Generic;
using System.Text;

namespace applestore.Application.DTOs {
    public class PagedViewModel<T> {
        List<T> Items {get; set;}
        public int totalRecord {get; set;}

    }
}