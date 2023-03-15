using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClass, params string[] fields)
        {
            Type type = Type.GetType(nameOfClass);
            StringBuilder stringBuilder = new($"Class under investigation: {type.Name}{Environment.NewLine}");
            FieldInfo[] fieldsInfo = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            foreach (FieldInfo fieldInfo in fieldsInfo.Where(x => fields.Contains(x.Name)))
            {
                stringBuilder.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(new Hacker())}");
            }
            return stringBuilder.ToString().Trim();
        }
    }
}
