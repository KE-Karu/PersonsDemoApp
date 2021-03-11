using PersonsDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonsDemoApp.Repositories
{
    public interface IPersonRepository : IRepository<Persons>
    {
        Task<IReadOnlyCollection<PersonalRelations>> GetRelativesByPersonId(int id);
    }
}
