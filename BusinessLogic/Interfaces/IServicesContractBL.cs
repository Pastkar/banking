using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IServicesContractBL
    {
        Task CreateAsync(ContractCreateBL element);
        Task<ContractGetBL> ReadByIdAsync(int id);
        Task<IEnumerable<ContractGetBL>> ReadAllAsync();
        Task DeleteAsync(int id);
        Task UpdateAsync(ContractCreateBL element, int id);
        Task CreatePayments(int id);
    }
}
