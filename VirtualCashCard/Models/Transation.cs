using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace VirtualCashCard.Models

{
    public class Transactions
    {
        public string Side { get; set; }
        public Decimal Amount { get; set; }

    }

}
