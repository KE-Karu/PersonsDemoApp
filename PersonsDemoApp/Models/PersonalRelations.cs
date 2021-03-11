namespace PersonsDemoApp.Models
{
    public class PersonalRelations : UniqueEntityData
    {
        public int PersonId { get; set; }
        public int RelativeId { get; set; }
        public RelationshipTypes RelationType { get; set; }
        public RelationshipTypes ReverseRelationType { get; set; }
        public Persons Person { get; set; }
    }
}
