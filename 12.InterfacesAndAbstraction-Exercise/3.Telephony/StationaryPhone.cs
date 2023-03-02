using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Call(string phoneNumber)
        {
            if (phoneNumber.Any(ch => !char.IsDigit(ch)))
            {
                Console.WriteLine("Invalid number!");
                return;
            }
            Console.WriteLine($"Dialing... {phoneNumber}");
        }
    }
}
