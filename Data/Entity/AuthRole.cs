using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace applestore.Data.Entity {
    public class AuthRole : IdentityRole<Guid> {
        public string brief {get; set;}
    }
}