using GraphQL.Types;

namespace PersonsDemoApp.InputTypes
{
    public class PersonalRelationsInputType : InputObjectGraphType
    {
        public PersonalRelationsInputType()
        {
            Name = "AddPersonalRelationsInput";
            Field<NonNullGraphType<IntGraphType>>("relativeId");
            Field<NonNullGraphType<IntGraphType>>("personId");
            Field<StringGraphType>("relationType");
            Field<StringGraphType>("reverseRelationType");
        }
    }
}
