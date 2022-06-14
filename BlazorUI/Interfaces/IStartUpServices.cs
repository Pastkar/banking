using CommonModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUI.Interfaces
{
    public interface IStartUpServices
    {
        Task<IEnumerable<StartUpGetModel>> GetStartUpsAsync();
        Task<bool> CheckStartUpByName(string name);
        Task CreateStartUpAsync(StartUpCreateModel clientCreate);
        Task<StartUpGetModel> GetByIdAsync(int id);
    }
}
