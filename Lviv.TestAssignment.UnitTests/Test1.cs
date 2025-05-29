using Lviv.TestAssignment.Database;
using Microsoft.EntityFrameworkCore;

namespace Lviv.TestAssignment.UnitTests
{
    [TestClass]
    public sealed class Test1
    {
        private static readonly AppDbContext _context = new(new DbContextOptions<AppDbContext>());

        [TestMethod]
        public void IfNoContactReturnError()
        {
            
        }
    }
}
