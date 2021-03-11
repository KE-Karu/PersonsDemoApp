using GraphQL.Types;
using GraphQL.Utilities;
using PersonsDemoApp.Mutations;
using PersonsDemoApp.Queries;
using System;

namespace PersonsDemoApp.Schemas
{
    public class PersonsSchema : Schema
    {
        public PersonsSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<PersonsQuery>();
            Mutation = provider.GetRequiredService<PersonsMutation>();
        }
    }
}
