using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountProjectCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string VatNumber { get; set; }
    }
}
