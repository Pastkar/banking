using AutoMapper;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class StartUpServices : IServicesStartUpBL, IDisposable
    {
        private IUnitOfWork _dB;
        private readonly IMapper _mapper;
        public StartUpServices(IMapper mapper)
        {
            _mapper = mapper;
            _dB = new UnitOfWork();
        }
        public async Task CreateAsync(StartUpCreateBL element)
        {
            var item = _mapper.Map<StartUp>(element);
            await _dB.StartUps.CreateAsync(item);
            await _dB.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _dB.StartUps.DeleteAsync(id);
            await _dB.SaveAsync();
        }

        public async Task<IEnumerable<StartUpGetBL>> ReadAllAsync()
        {
            var items = await _dB.StartUps.ReadAllAsync();
            var result = _mapper.Map<IEnumerable<StartUpGetBL>>(items);

            return result;
        }

        public async Task<StartUpGetBL> ReadByIdAsync(int id)
        {
            var items = await _dB.StartUps.ReadByIdAsync(id);
            var result = _mapper.Map<StartUpGetBL>(items);
            return result;
        }

        public async Task UpdateAsync(StartUpCreateBL element, int id)
        {
            var toUpdate = await _dB.StartUps.ReadByIdAsync(id);

            if (toUpdate != null)
            {
                toUpdate = _mapper.Map<StartUp>(element);
                await _dB.StartUps.UpdateAsync(toUpdate, id);
                await _dB.SaveAsync();
            }
        }
        public void Dispose()
        {
            _dB.Dispose();
        }

        public async Task<StartUpGetBL> ReadByNameAsync(string name)
        {
            var item = await _dB.StartUps.ReadByNameAsync(name);
            var result = _mapper.Map<StartUpGetBL>(item);
            return result;
        }

        public async Task<int> CountContractsByStartUpId(int id)
        {
            var list = _mapper.Map<IEnumerable<ContractGetBL>>(await _dB.Contracts.ReadAllAsync());
            return list.Where(contract => contract.StartUpId == id).Count();
        }
    }
}
