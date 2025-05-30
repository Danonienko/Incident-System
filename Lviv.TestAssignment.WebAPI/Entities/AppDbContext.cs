using Microsoft.EntityFrameworkCore;

namespace Lviv.TestAssignment.WebAPI.Entities
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
