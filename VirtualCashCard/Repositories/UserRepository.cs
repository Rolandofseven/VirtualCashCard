using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualCashCard.Models;

namespace VirtualCashCard
{
    public class UserRepository
    {

        public IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User {UserId = 1, Name = "Roland", Pin = 1234},
                new User {UserId = 2, Name = "Bob", Pin = 4321},
                new User {UserId = 3, Name = "Fred", Pin = 1111},
            };
        }

        public User GetUsersByCreds(string userName, int pin)
        {
            return GetUsers().FirstOrDefault(u => u.Name.ToLower() == userName.ToLower() && u.Pin == pin);
        }
    }

}
