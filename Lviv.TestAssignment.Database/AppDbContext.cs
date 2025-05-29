using Lviv.TestAssignment.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lviv.TestAssignment.Database
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
