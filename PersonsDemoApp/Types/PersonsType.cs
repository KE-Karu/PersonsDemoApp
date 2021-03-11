using GraphQL.Types;
using PersonsDemoApp.Models;
using PersonsDemoApp.Repositories;
using System.Collections.Generic;

namespace PersonsDemoApp.Types
{
    public class PersonsType : ObjectGraphType<Persons>
    {
        public PersonsType(IPersonRepository personRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Persons Id");
            Field(x => x.NatIdNr).Description("Persons Unique National Identification Number");
            Field(x => x.Nationality).Description("Persons Nationality");
            Field(x => x.FirstName).Description("Persons First Name");
            Field(x => x.LastName).Description("Persons Last Name");
            Field(x => x.DateOfBirth).Description("Persons Date of Birth");
            Field(x => x.DateOfDeath).Description("Persons Date of Death");
            Field(x => x.Address).Description("Persons Current Address");
            Field(x => x.Email).Description("Personal email");
            //Field(x => x.Gender).Description("Gender of the Person");

            Field<GenderType>(nameof(Persons.Gender));

            FieldAsync<ListGraphType<PersonalRelationsType>, IReadOnlyCollection<PersonalRelations>>(
                "personalRelations", "returns list of all personal relations",
                resolve: context =>
                {
                    return personRepository.GetRelativesByPersonId(context.Source.Id);
                });
        }
    }
}
