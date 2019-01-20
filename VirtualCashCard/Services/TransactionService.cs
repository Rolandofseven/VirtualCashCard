using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualCashCard.Models;

namespace VirtualCashCard.Services
{
    public class TransactionService
    {

        List<Transactions> _tranaction = null;
        BankAccount bankAccount = new BankAccount();


        public TransactionService()
        {
            _tranaction = new List<Transactions>();
        }

        public void CreditAccount()
        {
            Console.WriteLine("How much do wish to credit");
            string amount = Console.ReadLine();
            decimal amountToAdd;

            decimal.TryParse(amount, out amountToAdd);
            if (amountToAdd != 0)
            {
                BankAccount.Instance.AddTransaction(amountToAdd, "C");
            }
        }

        public void DebtAccount()
        {
            Console.WriteLine("How much do wish to debit");
            string amount = Console.ReadLine();
            decimal amountToDebit;

            decimal.TryParse(amount, out amountToDebit);


            if (amountToDebit != 0)
            {
                BankAccount.Instance.AddTransaction(amountToDebit, "D");
            }
        }

        public void ShowBalance()
        {
            var total = _tranaction.Sum(x => x.Side == "C" ? x.Amount : x.Amount * -1);
            Console.WriteLine(total);
        }
    }
}
