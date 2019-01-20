using System;
using System.Collections.Generic;
using System.Linq;
using VirtualCashCard.Models;
using VirtualCashCard.Services;
using VirtualCashCard.States;

namespace VirtualCashCard
{
    //Can withdraw money if a valid PIN is supplied.The balance on the card needs to adjust
    //accordingly.
    //2. Can be topped up any time by an arbitrary amount.
    //3. The cash card, being virtual, can be used in many places at the same time.

    class Program
    {
        private static List<Transactions> _tranaction;
        private TransactionService TransactionsBag;

        static void ShowMenu()
        {
            string menu = "1. Top up balance \n";
            menu += "2. Make a withdraw \n";
            menu += "3. Show Balance\n";
            menu += "4. Quit \n";

            Console.Write(menu);
        }

        static void CreditAccount()
        {
            Console.WriteLine("How much");
            string amount = Console.ReadLine();
            decimal amountToAdd;

            decimal.TryParse(amount, out amountToAdd);
            if (amountToAdd != 0)
            {
                _tranaction.Add(new Transactions{Side = "C", Amount = amountToAdd});
            }
        }

        static void DebtAccount()
        {
            Console.WriteLine("How much");
            string amount = Console.ReadLine();
            decimal amountToAdd;

            decimal.TryParse(amount, out amountToAdd);


            if (amountToAdd != 0)
            {
                _tranaction.Add(new Transactions { Side = "D", Amount = amountToAdd });
            }
        }

        static void ShowBalance()
        {
            var total = _tranaction.Sum(x => x.Side == "C" ? x.Amount : x.Amount * -1);
            Console.WriteLine(total);
        }

        static User SignUserIn()
        {
            Console.WriteLine("What is your name");
            string name = Console.ReadLine();

            Console.WriteLine("What is your pin");
            string pin = Console.ReadLine();

            var auth = new Authentication();

            var user = auth.SignIn(name, int.Parse(pin));

            if (user == null)
            {
                Console.WriteLine("Supplied name or pin are invalid");
                SignUserIn();
            }

            return user;
        }

        static void Main(string[] args)
        {
            CardMachine cardMachine = new CardMachine();
            cardMachine.SwitchOnMachine();

        }
    }
}
