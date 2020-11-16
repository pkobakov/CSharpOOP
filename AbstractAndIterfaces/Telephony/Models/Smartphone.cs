using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class Smartphone:ICallable, IBrowesable
    {
        public string Call(string phonenumber)
        {
            if (!phonenumber.All(x=>char.IsDigit(x)))
            {
                throw new Exception("Invalid number!");
            }
            return $"Calling... {phonenumber}";
        }

        public string Browse(string url) 
        {
            if (url.Any(x=>char.IsDigit(x)))
            {
                throw new Exception("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }
    }
}
