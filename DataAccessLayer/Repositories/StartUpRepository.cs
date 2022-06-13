using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class StartUpRepository : IRepository<StartUp>
    {
        private readonly Context _dB;
        public StartUpRepository(Context context)
        {
            _dB = context;
        }
        public async Task CreateAsync(StartUp item)
        {
            Company company = await _dB.Companies.FindAsync(item.CompanyId);
            if (company != null)
                item.Company = company;
                await _dB.StartUps.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var company = await _dB.StartUps.FindAsync(id);
            if (company != null)
                _dB.StartUps.Remove(company);
        }

        public async Task<IEnumerable<StartUp>> ReadAllAsync()
        {
            return await _dB.StartUps.ToListAsync();
        }

        public async Task<StartUp> ReadByIdAsync(int id)
        {
            return await _dB.StartUps.FindAsync(id);
        }

        public async Task<StartUp> ReadByNameAsync(string name)
        {
            return await _dB.StartUps.FirstOrDefaultAsync(startUp => startUp.StartUpName == name);
        }

        public async Task UpdateAsync(StartUp item, int id)
        {
            //var previousCompany = await _dB.StartUps.FindAsync(id);

            //if (previousCompany != null)
            //{
            //    _dB.StartUps.Remove(previousCompany);
            //    var newCompany = new StartUp()
            //    {
            //        Id = id,
            //        StartUpName = item.StartUpName,
            //    };

            //    await _dB.StartUps.AddAsync(newCompany);
            //}
        }
    }
}
