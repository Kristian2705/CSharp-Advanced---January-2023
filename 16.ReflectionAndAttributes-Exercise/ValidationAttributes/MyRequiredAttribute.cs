using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
            => obj != null;
        //{
        //    PropertyInfo property = obj as PropertyInfo;
        //    if (property != null)
        //    {
        //        MyRequiredAttribute myRequiredAttribute = property.GetCustomAttribute(typeof(MyRequiredAttribute)) as MyRequiredAttribute;
        //        if (myRequiredAttribute != null)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
