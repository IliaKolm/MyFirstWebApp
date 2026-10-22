using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace MyFirstWebApp.Data
{
    public class MyAplicationContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=Auto.db");
            }
        }
    }
}
