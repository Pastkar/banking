using CommonModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUI.Interfaces
{
    public interface IContractServices
    {
        Task CreateContractAsync(ContractCreateModel companyCreate);
        Task<IEnumerable<ContractGetModel>> GetContractByUserId(int id);
        Task<IEnumerable<ContractGetModel>> GetContractByStartUpId(int id);
        Task<bool> PayMonthlyFee(int id);

    }
}
