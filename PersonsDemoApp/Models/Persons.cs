using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsDemoApp.Models
{
    public class Persons : Dates
    {
        public string Email { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public Name Name { get; set; }
        public ICollection<Relations> PersonalRelations { get; set; }
    }
}
