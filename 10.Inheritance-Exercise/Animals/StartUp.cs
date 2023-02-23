using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new();
            string input = string.Empty;
            while((input = Console.ReadLine()) != "Beast!")
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);
                string gender = info[2];
                if(age < 0 || (gender != "Male" && gender != "Female"))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                switch (input)
                {
                    case "Dog":
                        Dog dog = new(name, age, gender);
                        animals.Add(dog);
                        break;
                    case "Frog":
                        Frog frog = new(name, age, gender);
                        animals.Add(frog);
                        break;
                    case "Cat":
                        Cat cat = new(name, age, gender);
                        animals.Add(cat);
                        break;
                    case "Kitten":
                        Kitten kitten = new(name, age);
                        animals.Add(kitten);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new(name, age);
                        animals.Add(tomcat);
                        break;
                }
            }
            foreach(var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
