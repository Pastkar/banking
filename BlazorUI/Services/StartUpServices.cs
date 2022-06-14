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
    public class StartUpServices : IStartUpServices
    {
        private readonly HttpClient httpClient;
        public StartUpServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> CheckStartUpByName(string name)
        {
            try
            {
                var client = await httpClient.GetFromJsonAsync<StartUpGetModel>("api/StartUp/GetStartUpByName_" + name);
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

        public async Task CreateStartUpAsync(StartUpCreateModel clientCreate)
        {
            using var response = await httpClient.PostAsJsonAsync("api/StartUp/PostStartUp", clientCreate);
        }

        public async  Task<StartUpGetModel> GetByIdAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<StartUpGetModel>("api/StartUp/GetStartUpById_" + id);

        }

        public  async Task<IEnumerable<StartUpGetModel>> GetStartUpsAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<StartUpGetModel>>("api/StartUp/GetStartUps");
        }
    }
}
