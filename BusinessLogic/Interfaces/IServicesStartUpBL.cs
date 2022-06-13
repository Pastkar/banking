using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IServicesStartUpBL
    {
        Task CreateAsync(StartUpCreateBL element);
        Task<StartUpGetBL> ReadByIdAsync(int id);
        Task<IEnumerable<StartUpGetBL>> ReadAllAsync();
        Task DeleteAsync(int id);
        Task UpdateAsync(StartUpCreateBL element, int id);
        Task<StartUpGetBL> ReadByNameAsync(string name);
    }
}
