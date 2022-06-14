using BlazorUI.Interfaces;
using CommonModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorUI.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly HttpClient httpClient;
        public CompanyServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> CheckCompanyByName(string name)
        {
            try
            {
                var client = await httpClient.GetFromJsonAsync<CompanyGetModel>("api/Company/GetCompanyByName_" + name);
                return true;
            }
            catch (Exception e)
            {
                if (e.Message == "Response status code does not indicate success: 404 (Not Found).")
                {
                    return false;
                }
                return false;
            }
        }

        public async Task CreateCompanyAsync(CompanyCreateModel companyCreate)
        {
            using var response = await httpClient.PostAsJsonAsync("api/Company/PostCompany", companyCreate);
        }

        public async Task<CompanyGetModel> GetCompanyById(int id)
        {
            return await httpClient.GetFromJsonAsync<CompanyGetModel>("api/Company/GetCompanyById_" + id);
        }

        public async Task<CompanyGetModel> GetCompanyByName(string name)
        {
            return await httpClient.GetFromJsonAsync<CompanyGetModel>("api/Company/GetCompanyByName_" + name);
        }

        public async Task<IEnumerable<CompanyGetModel>> GetCompanysAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<CompanyGetModel>>("api/Company/GetCompanies");
        }

        public async Task<IEnumerable<StartUpGetModel>> GetStartUpsByCompanyId(int id)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<IEnumerable<StartUpGetModel>>("api/Company/GetStartUpsByCompanyId_" + id);
            }
            catch (Exception e)
            {   
                return null;
            }
        }
    }
}
