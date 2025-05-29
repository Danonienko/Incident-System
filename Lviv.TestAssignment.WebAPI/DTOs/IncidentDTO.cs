using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Lviv.TestAssignment.WebAPI.DTOs
{
    [Index(nameof(ContactEmail), IsUnique = true)]
    public class IncidentDTO
    {
        [Required]
        public required string AccountName { get; set; }
        [Required]
        public required string ContactFirstName { get; set; }
        [Required]
        public required string ContactLastName { get; set; }

        [Required]
        [EmailAddress]
        public required string ContactEmail { get; set; }

        public string? IncidentDescription { get; set; }
    }
}
