using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.EF;
using DataAccessLayer.Repositories;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork: IUnitOfWork
    {
        private Context _dataBase { get; }
        private IRepository<Client> _clientRepository;
        private IRepository<StartUp> _startUpRepository;
        private IRepository<Contract> _contractRepository;
        private IRepository<Company> _companyRepository;

        public UnitOfWork()
        {
            _dataBase = new Context();
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (_clientRepository == null)
                    _clientRepository = new ClientRepository(_dataBase);
                return _clientRepository;
            }
        }
        public IRepository<StartUp> StartUps
        {
            get
            {
                if (_startUpRepository == null)
                    _startUpRepository = new StartUpRepository(_dataBase);
                return _startUpRepository;
            }
        }
        public IRepository<Contract> Contracts
        {
            get
            {
                if (_contractRepository == null)
                    _contractRepository = new ContractRepository(_dataBase);
                return _contractRepository;
            }
        }
        public IRepository<Company> Companies
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new CompanyRepository(_dataBase);
                return _companyRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _dataBase.SaveChangesAsync();    
        }

        public void Dispose()
        {
            _dataBase.Dispose();
        }
    }
}
