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
    public class CompanyRepository : IRepository<Company>
    {
        private readonly Context _dB;
        public CompanyRepository(Context context)
        {
            _dB = context;
        }

        public async Task CreateAsync(Company item)
        {
            await _dB.Companies.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var company = await _dB.Companies.FirstOrDefaultAsync(c => c.Id == id);
            if(company != null)
                _dB.Companies.Remove(company);
        }

        public async Task<IEnumerable<Company>> ReadAllAsync()
        {
            return await _dB.Companies.ToListAsync();
        }

        public async Task<Company> ReadByIdAsync(int id)
        {
            return await _dB.Companies.FindAsync(id);
        }

        public async Task<Company> ReadByNameAsync(string name)
        {
            return await _dB.Companies.FirstOrDefaultAsync(company => company.CompanyName == name);
        }

        public async Task UpdateAsync(Company item, int id)
        {

        }
    }
}
