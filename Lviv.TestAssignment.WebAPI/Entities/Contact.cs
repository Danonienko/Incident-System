using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Lviv.TestAssignment.WebAPI.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class Contact
    {
        public int Id { get; set; }

        public int? AccountId { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
