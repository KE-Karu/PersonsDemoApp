using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonsDemoApp.Models
{
    public class Person : Name
    {
        [Required]
        public string NatIdNr { get; set; }
        [Required]
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Required]
        public Gender Gender { get; set; }

        public ICollection<PersonalRelation> PersonalRelations { get; set; }
    }
}
