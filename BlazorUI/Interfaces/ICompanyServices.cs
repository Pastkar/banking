using CommonModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUI.Interfaces
{
    public interface ICompanyServices
    {
        Task<IEnumerable<CompanyGetModel>> GetCompanysAsync();
        Task CreateCompanyAsync(CompanyCreateModel companyCreate);
        Task<bool> CheckCompanyByName(string name);
        Task<CompanyGetModel> GetCompanyByName(string name);
        Task<CompanyGetModel> GetCompanyById(int id);
        Task<IEnumerable<StartUpGetModel>> GetStartUpsByCompanyId(int id);

    }
}
