using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<Contract> Operations { get; set; } 
    }
}
