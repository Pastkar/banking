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
    public class ContractRepository : IRepository<Contract>
    {
        private readonly Context _dB;
        public ContractRepository(Context context)
        {
            _dB = context;
        }
        public async Task CreateAsync(Contract item)
        {
            var client =await _dB.Clients.FindAsync(item.ClientId);
            var startUp = await _dB.StartUps.FindAsync(item.StartUpId);
            if (client != null && startUp != null)
            {
                item.Client = client;
                item.StartUp = startUp;
                item.PerMonthProfit = CalculationPerMonthProfit(item.TermInYear, item.InitialAmount, startUp.InterestRate);
                item.InterestRate = startUp.InterestRate;
                await _dB.Contracts.AddAsync(item);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var contract = await _dB.Contracts.FindAsync(id);
            if (contract != null)
                _dB.Contracts.Remove(contract);
        }

        public async Task<IEnumerable<Contract>> ReadAllAsync()
        {
            return await _dB.Contracts.ToListAsync();
        }

        public async Task<Contract> ReadByIdAsync(int id)
        {
             return await _dB.Contracts.FindAsync(id);
        }

        public async Task<Contract> ReadByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Contract item, int id)
        {
            var upateItem = await _dB.Contracts.FindAsync(id);
            if(upateItem != null)
            {
                upateItem.CurrentAmount = item.CurrentAmount;
            }

        }
        private int CalculationPerMonthProfit(int term, int ammount, int percent)
        {
            return ammount / (term * 12) + ammount * percent / 100 / 12;
        }
    }
}
