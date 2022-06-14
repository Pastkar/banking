using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class 
    {
        Task<IEnumerable<T>> ReadAllAsync();
        Task<T> ReadByIdAsync(int id);
        Task<T> ReadByNameAsync(string name);
        Task CreateAsync(T item);
        Task DeleteAsync(int id);
        Task UpdateAsync(T item, int id);
    }
}
