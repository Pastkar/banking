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
    public class ContractServices : IContractServices
    {
        private readonly HttpClient httpClient;
        public ContractServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task CreateContractAsync(ContractCreateModel companyCreate)
        {
            using var response = await httpClient.PostAsJsonAsync("api/Contract/PostContract", companyCreate);
        }

        public async Task<IEnumerable<ContractGetModel>> GetContractByStartUpId(int id)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<ContractGetModel>>("api/Contract/GetContactsByStartUpId_" + id);
        }

        public async Task<IEnumerable<ContractGetModel>> GetContractByUserId(int id)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<ContractGetModel>>("api/Contract/GetContactsByUserId_" + id);
        }

        public async Task<bool> PayMonthlyFee(int id)
        {
           return await httpClient.GetFromJsonAsync<bool>("api/Contract/AddPeymentById_" + id);
        }
    }
}
