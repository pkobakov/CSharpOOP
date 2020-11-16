using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class Stationaryphone:ICallable
    {
        public string Call(string phonenumber) 
        {
            if (!phonenumber.All(x=>char.IsDigit(x)))
            {
                throw new Exception("Invalid number!");
            }
            return $"Dialing... {phonenumber}";
        
        }
    }
}
