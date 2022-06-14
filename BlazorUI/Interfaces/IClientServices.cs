using CommonModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUI.Interfaces
{
    public interface IClientServices
    {
        Task<IEnumerable<ClientGetModel>> GetClientsAsync();
        Task CreateClientAsync(ClientCreateModel clientCreate);
        Task<bool> CheckClientByName(string name);
        Task<ClientGetModel> GetClientByName(string name);
    }
}
