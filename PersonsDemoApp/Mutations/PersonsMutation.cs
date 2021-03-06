using GraphQL;
using GraphQL.Types;
using PersonsDemoApp.InputTypes;
using PersonsDemoApp.Models;
using PersonsDemoApp.Repositories;
using PersonsDemoApp.Types;

namespace PersonsDemoApp.Mutations
{
    public class PersonsMutation : ObjectGraphType<object>
    {
        public PersonsMutation(IPersonRepository personRepository, IRelationRepository relationRepository)
        {
            Name = "PersonalRelationsMutation";

            #region Person
            FieldAsync<PersonsType>(
                "createPerson",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PersonsInputType>> { Name = "person" }
                    ),
                resolve: async context =>
                {
                    var personInput = context.GetArgument<Person>("person");
                    return await personRepository.Add(personInput);
                    //return "Person has been created succesfully.";
                }
            );

            FieldAsync<PersonsType>(
                "updatePerson",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PersonsInputType>> { Name = "person" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "personId" }
                    ),
                resolve: async context =>
                {
                    var personInput = context.GetArgument<Person>("person");
                    var personId = context.GetArgument<int>("personId");

                    var personInfoRetrived = await personRepository.GetById(personId);
                    if (personInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Person info."));
                        return null;
                    }
                    personInfoRetrived.NatIdNr = personInput.NatIdNr;
                    personInfoRetrived.Nationality = personInput.Nationality;
                    personInfoRetrived.Email = personInput.Email;
                    personInfoRetrived.FirstName = personInput.FirstName;
                    personInfoRetrived.LastName = personInput.LastName;
                    personInfoRetrived.DateOfBirth = personInput.DateOfBirth;
                    personInfoRetrived.DateOfDeath = personInput.DateOfDeath;
                    personInfoRetrived.Address = personInput.Address;
                    personInfoRetrived.Sex = personInput.Sex;
                    return await personRepository.Update(personInfoRetrived);
                    //return $"Person ID {personId} with Name {personInfoRetrived.FullName} has been updated succesfully.";
                }
            );

            FieldAsync<StringGraphType>(
                "deletePerson",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "personId" }),
                resolve: async context =>
                {
                    var personId = context.GetArgument<int>("personId");

                    var personInfoRetrived = await personRepository.GetById(personId);
                    if (personInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Person info."));
                        return null;
                    }
                    await personRepository.Delete(personId);
                    return $"Person ID {personId} with Name {personInfoRetrived.FullName} has been deleted succesfully.";
                }
            );
            #endregion


            #region Personal Relations
            FieldAsync<PersonalRelationsType>(
                "addRelation",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PersonalRelationsInputType>> { Name = "relation" }),
                resolve: async context =>
                {
                    var personalDisease = context.GetArgument<PersonalRelation>("relation");
                    return await relationRepository.Add(personalDisease);
                    //return $"Relationship has been created succesfully.";
                }
            );

            FieldAsync<PersonalRelationsType>(
                "updateRelation",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PersonalRelationsInputType>> { Name = "relation" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "relationId" }
                    ),
                resolve: async context =>
                {
                    var relationInput = context.GetArgument<PersonalRelation>("relation");
                    var relationId = context.GetArgument<int>("relationId");

                    var relationInfoRetrived = await relationRepository.GetById(relationId);
                    if (relationInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Relation info."));
                        return null;
                    }
                    relationInfoRetrived.PersonId = relationInput.PersonId;
                    relationInfoRetrived.RelativeId = relationInput.RelativeId;
                    relationInfoRetrived.RelationType = relationInput.RelationType;
                    relationInfoRetrived.ReverseRelationType = relationInput.ReverseRelationType;
                    return await relationRepository.Update(relationInfoRetrived);
                    //return $"Relation ID {relationId} has been updated succesfully.";
                }
            );

            FieldAsync<StringGraphType>(
                "deleteRelation",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "relationId" }),
                resolve: async context =>
                {
                    var relationId = context.GetArgument<int>("relationId");

                    var relationInfoRetrived = await relationRepository.GetById(relationId);
                    if (relationInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Personal Relation info."));
                        return null;
                    }
                    await relationRepository.Delete(relationId);
                    return $"Personal Relation ID {relationId} has been deleted succesfully.";
                }
            );
            #endregion
        }
    }
}
