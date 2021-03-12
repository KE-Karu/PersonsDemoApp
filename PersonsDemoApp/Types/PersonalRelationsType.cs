using GraphQL.Types;
using PersonsDemoApp.Models;
using PersonsDemoApp.Repositories;

namespace PersonsDemoApp.Types
{
    public class PersonalRelationsType : ObjectGraphType<PersonalRelation>
    {
        public PersonalRelationsType(IPersonRepository personRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Personal Relation Id");
            Field(x => x.PersonId, type: typeof(IdGraphType)).Description("Person Id");
            Field(x => x.RelativeId, type: typeof(IdGraphType)).Description("Relative Id");

            FieldAsync<PersonsType, Person>("relative", resolve: ctx =>
            {
                return personRepository.GetById(ctx.Source.PersonId);
            });

            FieldAsync<PersonsType, Person>("person", resolve: ctx =>
            {
                return personRepository.GetById(ctx.Source.PersonId);
            });

            Field<RelationshipTypesType>(nameof(PersonalRelation.RelationType));
            Field<RelationshipTypesType>(nameof(PersonalRelation.ReverseRelationType));

            //Field<RelationshipTypesType>(
            //    "relationshipTypes",
            //    resolve: x => x.Source.RelationType);

            //Field<RelationshipTypesType>(
            //    "relationshipTypes",
            //    resolve: x => x.Source.ReverseRelationType);
        }
    }
}
