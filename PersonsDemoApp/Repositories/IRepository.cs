using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsDemoApp.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Delete(int id);
        Task<T> Add(T obj);
        Task<T> Update(T obj);
    }
}
