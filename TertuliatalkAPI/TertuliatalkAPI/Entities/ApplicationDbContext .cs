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

        public DbSet<User> users { get; set; }
    }
}
