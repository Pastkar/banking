using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels.Models
{
    public class ContractCreateModel
    {
        public int ClientId { get; set; }
        public int StartUpId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int TermInYear { get; set; }
        public int InitialAmount { get; set; }
    }
}
