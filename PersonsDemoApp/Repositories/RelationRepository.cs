using PersonsDemoApp.AppDbContext;
using PersonsDemoApp.Models;

namespace PersonsDemoApp.Repositories
{
    public sealed class RelationRepository : UniqueEntityRepository<PersonalRelations>, IRelationRepository
    {
        public RelationRepository(PersonsDbContext c) : base(c, c.PersonalRelationships) { }
    }
}
