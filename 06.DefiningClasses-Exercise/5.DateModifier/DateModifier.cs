using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.DateModifier
{
    public class DateModifier
    {
        public void CalculateDifference(string firstDate, string secondDate)
        {
            string[] firstDateInfo = firstDate
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int year = int.Parse(firstDateInfo[0]);
            int month = int.Parse(firstDateInfo[1]);
            int day = int.Parse(firstDateInfo[2]);
            string[] secondDateInfo = secondDate
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int year2 = int.Parse(secondDateInfo[0]);
            int month2 = int.Parse(secondDateInfo[1]);
            int day2 = int.Parse(secondDateInfo[2]);
            DateTime first = new DateTime(year, month, day);
            DateTime second = new DateTime(year2, month2, day2);
            TimeSpan difference = first - second;
            Console.WriteLine(Math.Abs(difference.Days));
        }
    }
}
