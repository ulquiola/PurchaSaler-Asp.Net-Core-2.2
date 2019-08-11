using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PurchaSaler.Models;
using PurchaSaler.ViewModels;

namespace PurchaSaler.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public new DbSet<User> Users { get; set; }
        public DbSet<PurchaSaler.ViewModels.RegisterVM> UserVM { get; set; }
        public DbSet<PurchaSaler.ViewModels.LoginVM> LoginVM { get; set; }
    }
}
