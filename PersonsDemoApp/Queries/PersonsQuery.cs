using GraphQL;
using GraphQL.Types;
using PersonsDemoApp.Repositories;
using PersonsDemoApp.Types;

namespace PersonsDemoApp.Queries
{
    public class PersonsQuery : ObjectGraphType
    {
        public PersonsQuery(IPersonRepository personRepository, IRelationRepository relationRepository)
        {
            Name = "PersonsRelationsQuery";

            Field<PersonsType>(
               "person",
               arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "Id" }),
               resolve: context => personRepository.GetById(context.GetArgument<int>("Id"))
               );

            Field<ListGraphType<PersonsType>>(
                "persons", "Returns list of persons",
                resolve: context => personRepository.GetAll()
                );

            Field<PersonalRelationsType>(
                "relation",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "Id" }),
                resolve: context => relationRepository.GetById(context.GetArgument<int>("Id"))
                );

            Field<ListGraphType<PersonalRelationsType>>(
                "relations", "returns list of all persons relations",
                resolve: context => relationRepository.GetAll()
                );
        }
    }
}
