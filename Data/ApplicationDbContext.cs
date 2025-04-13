using Microsoft.EntityFrameworkCore;
using MVC_Project_13_April.Models;

namespace MVC_Project_13_April.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Product> products { get; set; }
    }
}
