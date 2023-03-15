using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new();
            Type type = Type.GetType(className);
            FieldInfo[] fieldsInfo = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] publicMethodsInfo = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethodsInfo = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach(var fieldInfo in fieldsInfo)
            {
                sb.AppendLine($"{fieldInfo.Name} must be private!");
            }
            foreach(var method in publicMethodsInfo.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            foreach(var method in nonPublicMethodsInfo.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);
            StringBuilder sb = new($"All Private Methods of Class: {className}{Environment.NewLine}Base Class: {type.BaseType.Name}{Environment.NewLine}");
            MethodInfo[] nonPublicMethodsInfo = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach(var methodInfo in nonPublicMethodsInfo)
            {
                sb.AppendLine($"{methodInfo.Name}");
            }
            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type type = Type.GetType(className);
            StringBuilder sb = new();
            MethodInfo[] methodsInfo = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach(var methodInfo in methodsInfo.Where(x => x.Name.StartsWith("get") || x.Name.StartsWith("set")))
            {
                if (methodInfo.Name.StartsWith("get"))
                {
                    sb.AppendLine($"{methodInfo.Name} will return {methodInfo.ReturnType}");
                }
                else
                {
                    sb.AppendLine($"{methodInfo.Name} will set field of {methodInfo.GetParameters().First().ParameterType}");
                }
            }
            return sb.ToString().Trim();
        }
    }
}
