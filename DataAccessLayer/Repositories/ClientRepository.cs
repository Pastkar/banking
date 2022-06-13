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
    public class ClientRepository : IRepository<Client>
    {
        private readonly Context _dB;
        public ClientRepository(Context context)
        {
            _dB = context;
        }
        public async Task CreateAsync(Client item)
        {
            await _dB.Clients.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            Client client = await _dB.Clients.FindAsync(id);
            if (client != null)
                _dB.Clients.Remove(client);
        }

        public async Task<IEnumerable<Client>> ReadAllAsync()
        {
            return await _dB.Clients.ToListAsync();
        }

        public async Task<Client> ReadByIdAsync(int id)
        {
            return await _dB.Clients.FindAsync(id);
        }

        public async Task<Client> ReadByNameAsync(string name)
        {
            return await _dB.Clients.FirstOrDefaultAsync(client => client.Login == name);
        }

        public async Task UpdateAsync(Client item, int id)
        {
            var previousClient = await _dB.Clients.FindAsync(id);

            if (previousClient != null)
            {
                _dB.Clients.Remove(previousClient);
                Client newClient = new Client()
                {
                    Id = id,
                    Login = item.Login,
                    Password = item.Password
                };

                await _dB.Clients.AddAsync(newClient);
            }
        }
    }
}
