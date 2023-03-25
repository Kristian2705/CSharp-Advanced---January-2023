using _1.Singleton.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Singleton.Models
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> capitals;
        private static SingletonDataContainer instance = new SingletonDataContainer();

        private SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");
            capitals = new Dictionary<string, int>();

            var elements = File.ReadAllLines("capitals.txt");
            for(int i = 0; i < elements.Length; i += 2)
            {
                capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }
        public static SingletonDataContainer Instance => instance;
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
