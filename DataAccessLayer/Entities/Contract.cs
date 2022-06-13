using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int TermInYear { get; set; }
        public int InterestRate { get; set; }
        public int InitialAmount { get; set; }
        public int CurrentAmount { get; set; }
        public int PerMonthProfit { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int StartUpId { get; set; }
        public StartUp StartUp { get; set; }
    }
}
