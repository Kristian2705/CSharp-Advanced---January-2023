using DIFramework.Attributes;
using DIFramework.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFramework.Modules
{
    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> implementations;
        private IDictionary<Type, object> instances;

        protected AbstractModule()
        {
            implementations = new Dictionary<Type, Dictionary<string, Type>>();
            instances = new Dictionary<Type, object>();
        }
        public abstract void Configure();

        public object GetInstance(Type type)
        {
            instances.TryGetValue(type, out object value);
            return value;
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            var currentImplementation = implementations[currentInterface];
            Type type = null;
            if(attribute is Inject)
            {
                if(currentImplementation.Count == 1)
                {
                    type = currentImplementation.Values.First();
                }
                else
                {
                    throw new ArgumentException($"No available mapping for class: {currentInterface.FullName}");
                }
            }
            else if(attribute is Named)
            {
                Named named = attribute as Named;
                string dependencyName = named.Name;
                type = currentImplementation[dependencyName];
            }
            return type;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!instances.ContainsKey(implementation))
            {
                instances.Add(implementation, instance);
            }
        }

        protected void CreateMapping<TInterface, TImplementation>()
        {
            if(!this.implementations.ContainsKey(typeof(TInterface)))
            {
                implementations[typeof(TInterface)] = new Dictionary<string, Type>();
            }
            implementations[typeof(TInterface)].Add(typeof(TImplementation).Name, typeof(TImplementation));
        }
    }
}
