using GraphQL.Types;

namespace PersonsDemoApp.InputTypes
{
    public class PersonsInputType : InputObjectGraphType
    {
        public PersonsInputType()
        {
            Name = "AddPersonInput";
            Field<StringGraphType>("natIdNr");
            Field<StringGraphType>("nationality");
            Field<StringGraphType>("firstName");
            Field<StringGraphType>("lastName");
            //Field<DateGraphType>("dateOfBirth");
            //Field<DateGraphType>("dateOfDeath");
            Field<StringGraphType>("email");
            Field<StringGraphType>("address");
            Field<StringGraphType>("sex");
        }
    }
}
