using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IServicesClientBL
    {
        Task CreateAsync(ClientCreateBL element);
        Task<ClientGetBL> ReadByIdAsync(int id);
        Task<IEnumerable<ClientGetBL>> ReadAllAsync();
        Task DeleteAsync(int id);
        Task UpdateAsync(ClientCreateBL element, int id);
        Task<ClientGetBL> ReadByNameAsync(string name);

    }
}
