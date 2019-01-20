

using System.Collections.Generic;
using System.Linq;
using VirtualCashCard.Models;

namespace VirtualCashCard.Services
{
    public sealed class BankAccount
    {
        private readonly List<Transactions> _transactions;
        private static BankAccount _instance = null;

        public BankAccount()
        {
            _transactions = new List<Transactions>();
        }

        public void AddTransaction(decimal amount, string side)
        {
            _transactions.Add(new Transactions{Amount = amount, Side = side});
        }

        public decimal GetCurrentBalance()
        {
            return _transactions.Sum(x => x.Side == "C" ? x.Amount : x.Amount * -1);
        }

        public void ResetAccount()
        {
            _transactions.Clear();
        }

        public static BankAccount Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BankAccount();
                }
                return _instance;
            }
        }
    }
}
