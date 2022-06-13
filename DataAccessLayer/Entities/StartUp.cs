using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class StartUp
    {
        public int Id { get; set; }
        public string StartUpName { get; set; }
        public int InterestRate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
