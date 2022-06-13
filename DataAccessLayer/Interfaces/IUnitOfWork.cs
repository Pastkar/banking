using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Client> Clients { get; }
        IRepository<StartUp> StartUps { get; }
        IRepository<Contract> Contracts { get; }
        IRepository<Company> Companies { get; }
        Task SaveAsync();
    }
}
