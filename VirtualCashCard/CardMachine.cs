using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using VirtualCashCard.Models;
using VirtualCashCard.Services;
using VirtualCashCard.States;

namespace VirtualCashCard
{
    public class CardMachine
    {
        public string CurrentState = "NO_CARD";
        private readonly TransactionService _transactonService;
        private User _currentUser;
        private bool _running = true;
       
        public CardMachine()
        {
            _transactonService = new TransactionService();
        }

        public void ChangeScreen(string nextScreen)
        {
            Console.Clear();
            CurrentState = nextScreen;
        }

        private void ProcessMainMenu(int menuOption)
        {
            switch (menuOption)
            {
                case 1:
                    _transactonService.CreditAccount();
                    break;
                case 2:
                    _transactonService.DebtAccount();
                    break;
                case 3:
                    ChangeScreen("SHOW_BALANCE");
                    break;
                case 4:
                    _running = false;
                    break;

            }
        }

        public void SwitchOnMachine()
        {
            do
            {
                switch (CurrentState)
                {
                    case "NO_CARD":
                        _currentUser = new NoCardState().GetUser();
                        if (_currentUser != null)
                        {
                            ChangeScreen("SHOW_MENU");
                        }
                        break;
                    case "SHOW_BALANCE":
                        (new ShowBalance()).ShowScreen();
                        ChangeScreen("SHOW_MENU");
                        break;
                    case "SHOW_MENU":
                        int menuSelction = new MainMenuState().ShowScreen();
                        ProcessMainMenu(menuSelction);
                        break;
                }
            } while (_running);

        }
    }
}
