using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone()
        {

        }

        public void Browse(string url)
        {
            if (url.Any(ch => char.IsDigit(ch)))
            {
                Console.WriteLine("Invalid URL!");
                return;
            }
            Console.WriteLine($"Browsing: {url}!");
        }

        public void Call(string phoneNumber)
        {
            if(phoneNumber.Any(ch => !char.IsDigit(ch)))
            {
                Console.WriteLine("Invalid number!");
                return;
            }
            Console.WriteLine($"Calling... {phoneNumber}");
        }
    }
}
