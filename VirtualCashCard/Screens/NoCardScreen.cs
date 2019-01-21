using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualCashCard.Models;

namespace VirtualCashCard.States  
{
    public class NoCardState 
    {
        private readonly UserRepository  _userRepository;

        public NoCardState()
        {
            _userRepository = new UserRepository();
        }
        public User GetUser()
        {
            int pinNumber;

            Console.WriteLine("Please enter your name");
            string nameEntered = Console.ReadLine();

            Console.WriteLine("Please enter your pin number");
            string pinEntered = Console.ReadLine();

            int.TryParse(pinEntered, out pinNumber);

            User user = _userRepository.GetUsersByCreds(nameEntered, pinNumber);

            if (user == null)
            {
                Console.WriteLine("User not found");
            }

            return user;
        }
    }
}
