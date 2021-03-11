using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonsDemoApp.Models
{
    public class Persons : Name
    {
        [Required]
        public string NatIdNr { get; set; }
        [Required]
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Required]
        public Gender Gender { get; set; }

        public ICollection<PersonalRelations> PersonalRelations { get; set; }
    }
}
