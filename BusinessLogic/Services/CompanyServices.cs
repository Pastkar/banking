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
    public class CompanyServices : IServicesCompany, IDisposable
    {
        private IUnitOfWork _dB;
        private readonly IMapper _mapper;
        public CompanyServices(IMapper mapper)
        {
            _mapper = mapper;
            _dB = new UnitOfWork();
        }
        public async Task CreateAsync(CompanyCreateBL element)
        {
            var item = _mapper.Map<Company>(element);
            await _dB.Companies.CreateAsync(item);
            await _dB.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _dB.Companies.DeleteAsync(id);
            await _dB.SaveAsync();
        }

        public async Task<IEnumerable<CompanyGetBL>> ReadAllAsync()
        {
            var items = await _dB.Companies.ReadAllAsync();
            var result = _mapper.Map<IEnumerable<CompanyGetBL>>(items);

            return result;
        }

        public async Task<CompanyGetBL> ReadByIdAsync(int id)
        {
            var item = await _dB.Companies.ReadByIdAsync(id);
            var result = _mapper.Map<CompanyGetBL>(item);
            return result;
        }

        public async Task UpdateAsync(CompanyCreateBL element, int id)
        {
            var toUpdate = await _dB.Companies.ReadByIdAsync(id);

            if (toUpdate != null)
            {
                toUpdate = _mapper.Map<Company>(element);
                await _dB.Companies.UpdateAsync(toUpdate, id);
                await _dB.SaveAsync();
            }
        }
        public void Dispose()
        {
            _dB.Dispose();
        }

        public Task<CompanyGetBL> ReadByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
