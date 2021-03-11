using Microsoft.EntityFrameworkCore;
using PersonsDemoApp.AppDbContext;
using PersonsDemoApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsDemoApp.Repositories
{
    public sealed class PersonRepository : UniqueEntityRepository<Persons>, IPersonRepository
    {
        private readonly PersonsDbContext context;
        public PersonRepository(PersonsDbContext con) : base(con, con.Persons) { context = con; }

        public async Task<IReadOnlyCollection<PersonalRelations>> GetRelativesByPersonId(int personId)
        {
            return await context.PersonalRelationships.Where(o => o.PersonId == personId).ToListAsync();
        }
    }
}
