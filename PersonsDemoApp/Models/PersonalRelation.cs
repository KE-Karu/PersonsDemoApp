namespace PersonsDemoApp.Models
{
    public class PersonalRelation : UniqueEntityData
    {
        public int PersonId { get; set; }
        public int RelativeId { get; set; }
        public RelationshipType RelationType { get; set; }
        public RelationshipType ReverseRelationType { get; set; }
        public Person Person { get; set; }
    }
}
