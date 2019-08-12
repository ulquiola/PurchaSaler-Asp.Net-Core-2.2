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

        // protected public override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<UserAddress>().HasKey(x=> new {
        //         x.UserId,x.AddressId
        //     });
            
        // }
        public new DbSet<User> Users { get; set; }
        public DbSet<Shops> Shops { get; set; }
        public DbSet<Address> Addresses { get; set;}
        public DbSet<UserAddress> UserAddresses { get; set; }
    }
}
