using System;
using System.Collections.Generic;
using System.Linq;
using VirtualCashCard.Models;

namespace VirtualCashCard
{
    public class Authentication{
        public User SignIn(string userName, int pin)
        {
            return (new UserRepository()).GetUsersByCreds(userName, pin);
        }

    }

}