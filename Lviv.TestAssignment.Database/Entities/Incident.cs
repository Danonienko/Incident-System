using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lviv.TestAssignment.Database.Entities
{
    public class Incident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public Collection<Account> Accounts { get; } = [];
    }
}
