using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaSaler.Models
{
    public class User:IdentityUser
    {
        public String PhotoPath { get; set; }
    }
}
