using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Lviv.TestAssignment.Database.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        public int? AccountId { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        [EmailAddress]
        public required string Email { get; set; }
    }
}
