using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualCashCard.Services;

namespace VirtualCashCard.States
{
    public class ShowBalance
    {
        public void ShowScreen()
        {
            decimal currentBalance = BankAccount.Instance.GetCurrentBalance();

            Console.WriteLine($"Your current balance is {currentBalance} \n\n");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
}
