using PersonsDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonsDemoApp.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<IReadOnlyCollection<PersonalRelation>> GetRelativesByPersonId(int id);
    }
}
