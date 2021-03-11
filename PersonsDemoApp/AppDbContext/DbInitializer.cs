using PersonsDemoApp.Models;
using System;
using System.Linq;

namespace PersonsDemoApp.AppDbContext
{
    public class DbInitializer
    {
        public static void Initialize(PersonsDbContext context)
        {
            if (context.Persons.Any())
            {
                return;
            }
            var persons = new Persons[]
            {
                new Persons{ NatIdNr = "34501234215 ", Nationality="EST", FirstName = "Ants", LastName= "Mustikas", DateOfBirth = DateTime.Parse("03-01-1945"), Address = "Viru 10", Gender = Gender.Male},
                new Persons{ NatIdNr = "39502114232", Nationality="ENG", FirstName = "Tõnu", LastName=" Vaarikas", DateOfBirth = DateTime.Parse("11-02-1995"), DateOfDeath = DateTime.Parse("01-01-2021"), Address = "Maardu 25", Gender = Gender.Male},
                new Persons{ NatIdNr = "49403136515", Nationality="EST", FirstName = "Mari", LastName=" Maasikas", DateOfBirth = DateTime.Parse("13-03-1994"), Address = "Lepa 32", Gender = Gender.Female}
            };
            foreach (Persons p in persons)
            {
                context.Persons.Add(p);
            }
            context.SaveChanges();


            if (context.PersonalRelationships.Any())
            {
                return;
            }
            var relations = new PersonalRelations[]
            {
                new PersonalRelations{ PersonId = 1, RelativeId = 2, RelationType = RelationshipTypes.Son, ReverseRelationType = RelationshipTypes.Father},
                new PersonalRelations{ PersonId = 2, RelativeId = 1, RelationType = RelationshipTypes.Father, ReverseRelationType = RelationshipTypes.Son},
                new PersonalRelations{ PersonId = 3, RelativeId = 2, RelationType = RelationshipTypes.Partner, ReverseRelationType = RelationshipTypes.Partner},               
                new PersonalRelations{ PersonId = 2, RelativeId = 3, RelationType = RelationshipTypes.Partner, ReverseRelationType = RelationshipTypes.Partner}
            };
            foreach (PersonalRelations d in relations)
            {
                context.PersonalRelationships.Add(d);
            }
            context.SaveChanges();
        }
    }
}
