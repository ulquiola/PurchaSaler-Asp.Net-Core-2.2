using Microsoft.EntityFrameworkCore;

namespace PurchaSaler.Models
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            :base(options)
        {
            
        }
        public DbSet<Good> Good {get;set;}
    }
}