using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TertuliatalkAPI.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<user> users { get; set; }
    }
}
