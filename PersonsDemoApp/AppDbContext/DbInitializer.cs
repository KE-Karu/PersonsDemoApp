using PersonsDemoApp.Models;
using System;
using System.Linq;

namespace PersonsDemoApp.AppDbContext
{
    //public class DbInitializer
    //{
    //    public static void Initialize(PersonsDbContext context)
    //    {
    //        if (context.Persons.Any())
    //        {
    //            return;
    //        }
    //        var persons = new Person[]
    //        {
    //            new Person{ NatIdNr = "34501234215 ", Nationality="EST", FirstName = "Ants", LastName= "Mustikas", DateOfBirth = DateTime.Parse("03-01-1945"), Address = "Viru 10", Sex = "Male"},
    //            new Person{ NatIdNr = "39502114232", Nationality="ENG", FirstName = "Tõnu", LastName=" Vaarikas", DateOfBirth = DateTime.Parse("11-02-1995"), DateOfDeath = DateTime.Parse("01-01-2021"), Address = "Maardu 25", Sex = "Male"},
    //            new Person{ NatIdNr = "49403136515", Nationality="EST", FirstName = "Mari", LastName=" Maasikas", DateOfBirth = DateTime.Parse("13-03-1994"), Address = "Lepa 32", Sex = "Female"}
    //        };
    //        foreach (Person p in persons)
    //        {
    //            context.Persons.Add(p);
    //        }
    //        context.SaveChanges();


    //        if (context.PersonalRelationships.Any())
    //        {
    //            return;
    //        }
    //        var relations = new PersonalRelation[]
    //        {
    //            new PersonalRelation{ PersonId = 1, RelativeId = 2, RelationType = RelationshipType.Son, ReverseRelationType = RelationshipType.Father},
    //            new PersonalRelation{ PersonId = 2, RelativeId = 1, RelationType = RelationshipType.Father, ReverseRelationType = RelationshipType.Son},
    //            new PersonalRelation{ PersonId = 3, RelativeId = 2, RelationType = RelationshipType.Partner, ReverseRelationType = RelationshipType.Partner},               
    //            new PersonalRelation{ PersonId = 2, RelativeId = 3, RelationType = RelationshipType.Partner, ReverseRelationType = RelationshipType.Partner}
    //        };
    //        foreach (PersonalRelation d in relations)
    //        {
    //            context.PersonalRelationships.Add(d);
    //        }
    //        context.SaveChanges();
    //    }
    //}
}
