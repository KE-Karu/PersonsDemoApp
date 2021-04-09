using Microsoft.EntityFrameworkCore;
using PersonsDemoApp.AppDbContext;
using PersonsDemoApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsDemoApp.Repositories
{
    public sealed class PersonRepository : UniqueEntityRepository<Person>, IPersonRepository
    {
        private readonly PersonsDbContext context;
        public PersonRepository(PersonsDbContext con) : base(con, con.Persons) { context = con; }

        public async Task<IReadOnlyCollection<PersonalRelation>> GetRelativesByPersonId(int personId)
        {
            var query = context.PersonalRelationships.AsNoTracking().Where(o => o.Id == personId);
            return await query.ToListAsync();
            //return await context.PersonalRelationships.Where(o => o.PersonId == personId).ToListAsync();
        }
    }
}
