using Microsoft.EntityFrameworkCore;
using PersonsDemoApp.Models;
using System.Threading.Tasks;

namespace PersonsDemoApp.Repositories
{
    public abstract class UniqueEntityRepository<TData> : BaseRepository<TData>
         where TData : UniqueEntityData, new()
    {
        protected UniqueEntityRepository(DbContext c, DbSet<TData> s) : base(c, s) { }

        protected override async Task<TData> GetData(int id) =>
            await dbSet.FirstOrDefaultAsync(m => m.Id == id);

        protected override TData GetDataById(TData d) => dbSet.Find(d.Id);
    }
}
