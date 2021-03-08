using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsDemoApp.Models
{
    public class Relations : UniqueEntityData
    {
        public int PersonId { get; set; }
        public int RelativeId { get; set; }
        public Relationships RelationType { get; set; }
        public Relationships ReverseRelationType { get; set; }
        public Persons Person { get; set; }
    }
}
