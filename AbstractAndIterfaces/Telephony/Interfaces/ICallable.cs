using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Telephony.Interfaces
{
    public interface ICallable
    {
        public string Call(string phonenumber); 
    }
}
