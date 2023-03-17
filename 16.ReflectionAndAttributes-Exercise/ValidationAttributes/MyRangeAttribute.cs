using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
            => (int)obj >= minValue && (int)obj <= maxValue;
        //{
        //    PropertyInfo property = obj as PropertyInfo;
        //    Type typeOfPerson = Assembly.GetExecutingAssembly().GetTypes().First(x => x.Name == "Person");
        //    Person person = Activator.CreateInstance(typeOfPerson, null, -1) as Person;
        //    if (property != null)
        //    {
        //        if((int)property.GetValue(person) > minValue && (int)property.GetValue(person) < maxValue)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
