using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualCashCard.States
{
    public class MainMenuScreen
    {
        public int ShowScreen()
        {
            int menuItemSelected;

            string menu = "1. Top up balance \n";
            menu += "2. Make a withdraw \n";
            menu += "3. Show Balance\n";
            menu += "4. Quit \n";

            Console.Write(menu);

            int.TryParse(Console.ReadLine(), out menuItemSelected);

            return menuItemSelected;
        }
    }
}
