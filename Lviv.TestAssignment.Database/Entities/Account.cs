using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Lviv.TestAssignment.Database.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Account
    {
        public int Id { get; set; }

        public string? IncidentId { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        public Collection<Contact> Contacts { get; } = [];
    }
}
