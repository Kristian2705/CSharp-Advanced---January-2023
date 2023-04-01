using DIFramework.Injectors;
using DIFramework.Modules.Contracts;

namespace DIFramework
{
    public class DependencyInjection
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}