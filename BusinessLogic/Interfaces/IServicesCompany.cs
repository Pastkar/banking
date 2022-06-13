using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IServicesCompany
    {
        Task CreateAsync(CompanyCreateBL element);
        Task<CompanyGetBL> ReadByIdAsync(int id);
        Task<IEnumerable<CompanyGetBL>> ReadAllAsync();
        Task DeleteAsync(int id);
        Task UpdateAsync(CompanyCreateBL element, int id);
        Task<CompanyGetBL> ReadByNameAsync(string name);

    }
}
