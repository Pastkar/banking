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
            var client = await httpClient.GetFromJsonAsync<IEnumerable<ClientGetModel>>("/Client/GetClientByName_" + name);
            return true;
        }

        public async Task CreateClientAsync(ClientCreateModel clientCreate)
        {
            using var response = await httpClient.PostAsJsonAsync("api/Client/PostClient", clientCreate);
        }

        public async Task<IEnumerable<ClientGetModel>> GetClientsAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<ClientGetModel>>("api/Client/GetClients");
        }
    }
}
