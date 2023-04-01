using DIFramework.Attributes;
using DIFramework.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DIFramework.Injectors
{
    public class Injector
    {
        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            var hasConstructorAttribute = CheckForConstructorInjection<TClass>();
            var hasFieldAttribute = CheckForFieldInjection<TClass>();
            if(hasConstructorAttribute && hasFieldAttribute)
            {
                throw new ArgumentException("There must be only field or constructor annotated with Inject attribute");
            }
            if (hasConstructorAttribute)
            {
                return CreateConstructorInjection<TClass>();
            }
            if(hasFieldAttribute)
            {
                return CreateFieldInjection<TClass>();
            }
            return default(TClass);
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields((BindingFlags)62)
                .Any(f => f.GetCustomAttributes(typeof(Inject), true).Any());
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass)
                .GetConstructors()
                .Any(f => f.GetCustomAttributes(typeof(Inject), true).Any());
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            var desiredClass = typeof(TClass);
            if (desiredClass == null)
            {
                return default(TClass);
            }
            var constructors = desiredClass.GetConstructors();
            foreach (var constructor in constructors)
            {
                if (!CheckForConstructorInjection<TClass>())
                {
                    continue;
                }
                var inject = (Inject)constructor
                    .GetCustomAttributes(typeof(Inject), true)
                    .FirstOrDefault();
                var parametersType = constructor.GetParameters();
                var constructorParams = new object[parametersType.Length];

                int i = 0;

                foreach (var param in parametersType)
                {
                    var named = param.GetCustomAttribute(typeof(Named));
                    Type dependency = null;

                    if (named == null)
                    {
                        dependency = module.GetMapping(param.ParameterType, inject);
                    }
                    else
                    {
                        dependency = module.GetMapping(param.ParameterType, named);
                    }
                    if (param.ParameterType.IsAssignableFrom(dependency))
                    {
                        object instance = module.GetInstance(dependency);
                        if (instance != null)
                        {
                            constructorParams[i++] = instance;
                        }
                        else
                        {
                            instance = Activator.CreateInstance(dependency);
                            constructorParams[i++] = instance;
                            module.SetInstance(param.ParameterType, instance);
                        }
                    }
                }
                return (TClass)Activator.CreateInstance(desiredClass, constructorParams);
            }
            return default(TClass);
        }

        private TClass CreateFieldInjection<TClass>()
        {
            var desiredClass = typeof(TClass);
            var desiredClassInstance = module.GetInstance(desiredClass);
            if (desiredClassInstance == null)
            {
                desiredClassInstance = Activator.CreateInstance(desiredClass);
                module.SetInstance(desiredClass, desiredClassInstance);
            }
            var fields = desiredClass.GetFields((BindingFlags)62);
            foreach (var field in fields)
            {
                if(field.GetCustomAttributes(typeof(Inject), true).Any())
                {
                    var injection = (Inject)field
                        .GetCustomAttributes(typeof(Inject), true)
                        .FirstOrDefault();
                    Type dependency = null;
                    var named = field.GetCustomAttribute(typeof(Named), true);
                    var type = field.FieldType;
                    if(named == null)
                    {
                        dependency = module.GetMapping(type, injection);
                    }
                    else
                    {
                        dependency = module.GetMapping(type, named);
                    }
                    if (type.IsAssignableFrom(dependency))
                    {
                        object instance = module.GetInstance(dependency);
                        if(instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            module.SetInstance(dependency, instance);
                        }
                        field.SetValue(desiredClassInstance, instance);
                    }
                }
            }
            return (TClass)desiredClassInstance;
        }
    }
}
