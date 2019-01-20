using System;
using System.Collections.Generic;
using System.Linq;

namespace VirtualCashCard
{

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Pin { get; set; }
    }


    public class Authentication{
        public User SignIn(string userName, int pin)
        {
            return (new UserRepository()).GetUsersByCreds(userName, pin);
        }

    }

}