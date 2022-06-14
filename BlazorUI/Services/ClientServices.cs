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
    public class ClientServices : IClientServices
    {
        private readonly HttpClient httpClient;
        public ClientServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> CheckClientByName(string name)
        {
            try
            {
                var client = await httpClient.GetFromJsonAsync<ClientGetModel>("api/Client/GetClientByName_" + name);
                return true;
            }
            catch(Exception e)
            {
                if(e.Message == "Response status code does not indicate success: 404 (Not Found).")
                {
                    return false;
                }
                return false;
            }
        }

        public async Task CreateClientAsync(ClientCreateModel clientCreate)
        {
            using var response = await httpClient.PostAsJsonAsync("api/Client/PostClient", clientCreate);
        }

        public async Task<ClientGetModel> GetClientByName(string name)
        {
            return await httpClient.GetFromJsonAsync<ClientGetModel>("api/Client/GetClientByName_" + name);
        }

        public async Task<IEnumerable<ClientGetModel>> GetClientsAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<ClientGetModel>>("api/Client/GetClients");
        }
    }
}
