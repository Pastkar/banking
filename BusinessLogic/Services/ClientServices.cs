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
    public class ClientServices : IServicesClientBL, IDisposable
    {
        private IUnitOfWork _dB;
        private readonly IMapper _mapper;
        public ClientServices(IMapper mapper)
        {
            _mapper = mapper;
            _dB = new UnitOfWork();
        }
        public async Task CreateAsync(ClientCreateBL element)
        {
            var item = _mapper.Map<Client>(element);
            await _dB.Clients.CreateAsync(item);
            await _dB.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _dB.Clients.DeleteAsync(id);
            await _dB.SaveAsync();
        }

        public async Task<IEnumerable<ClientGetBL>> ReadAllAsync()
        {
            var items = await _dB.Clients.ReadAllAsync();
            var result = _mapper.Map<IEnumerable<ClientGetBL>>(items);

            return result;
        }

        public async Task<ClientGetBL> ReadByIdAsync(int id)
        {
            var items = await _dB.Clients.ReadByIdAsync(id);
            var result = _mapper.Map<ClientGetBL>(items);
            return result;
        }

        public async Task UpdateAsync(ClientCreateBL element, int id)
        {
            var toUpdate = await _dB.Clients.ReadByIdAsync(id);

            if (toUpdate != null)
            {
                toUpdate = _mapper.Map<Client>(element);
                await _dB.Clients.UpdateAsync(toUpdate, id);
                await _dB.SaveAsync();
            }
        }
        public void Dispose()
        {
            _dB.Dispose();
        }

        public async Task<ClientGetBL> ReadByNameAsync(string name)
        {
            var items = await _dB.Clients.ReadByNameAsync(name);
            var result = _mapper.Map<ClientGetBL>(items);
            return result;
        }
    }
}
