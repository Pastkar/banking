using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class StartUpGetBL
    {
        public int Id { get; set; }
        public string StartUpName { get; set; }
        public int CompanyId { get; set; }
        public int InterestRate { get; set; }
    }
}
