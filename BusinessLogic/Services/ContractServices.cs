using AutoMapper;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using System;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ContractServices : IServicesContractBL,IDisposable
    {
        private IUnitOfWork _dB;
        private readonly IMapper _mapper;
        public ContractServices(IMapper mapper)
        {
            _mapper = mapper;
            _dB = new UnitOfWork();
        }
        public async Task CreateAsync(ContractCreateBL element)
        {
            var item = _mapper.Map<Contract>(element);
            await _dB.Contracts.CreateAsync(item);
            await _dB.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _dB.Contracts.DeleteAsync(id);
            await _dB.SaveAsync();
        }
        public async Task<IEnumerable<ContractGetBL>> ReadAllAsync()
        {
            var items = await _dB.Contracts.ReadAllAsync();
            var result = _mapper.Map<IEnumerable<ContractGetBL>>(items);

            return result;
        }

        public async Task<ContractGetBL> ReadByIdAsync(int id)
        {
            var items = await _dB.Contracts.ReadByIdAsync(id);
            var result = _mapper.Map<ContractGetBL>(items);
            return result;
        }

        public async Task UpdateAsync(ContractCreateBL element, int id)
        {
            var toUpdate = await _dB.Contracts.ReadByIdAsync(id);

            if (toUpdate != null)
            {
                toUpdate = _mapper.Map<Contract>(element);
                await _dB.Contracts.UpdateAsync(toUpdate, id);
                await _dB.SaveAsync();
            }
        }
       
        public void Dispose()
        {
            _dB.Dispose();
        }

        public async Task CreatePayments(int id)
        {
            var item = await _dB.Contracts.ReadByIdAsync(id);
            if (item != null) {
                item.CurrentAmount += item.PerMonthProfit;
                await _dB.Contracts.UpdateAsync(item, id);
                await _dB.SaveAsync();
                }
        }

        public async Task<IEnumerable<ContractGetBL>> ContractsGetByUserId(int id)
        {
            var list = _mapper.Map<IEnumerable<ContractGetBL>>(await _dB.Contracts.ReadAllAsync());
            return list.Where(contract => contract.ClientId == id);
        }

        public async Task<IEnumerable<ContractGetBL>> ContractsGetByStartUpId(int id)
        {
            var list = _mapper.Map<IEnumerable<ContractGetBL>>(await _dB.Contracts.ReadAllAsync());
            return list.Where(contract => contract.StartUpId == id);
        }
    }
}
