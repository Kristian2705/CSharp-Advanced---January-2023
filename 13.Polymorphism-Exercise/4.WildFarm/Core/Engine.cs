﻿using _4.WildFarm.Core.Interfaces;
using _4.WildFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.WildFarm.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine()
        {
            reader = new ConsoleReader();
            writer = new ConsoleWriter();
        }
        public void Start()
        {
            List<Animal> animals = new();
            string input = string.Empty;
            while ((input = reader.ReadLine()) != "End")
            {
                string[] animalInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string animalType = animalInfo[0];
                Animal animal = null;
                switch (animalType)
                {
                    case "Owl":
                        animal = new Owl(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
                        break;
                    case "Hen":
                        animal = new Hen(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
                        break;
                    case "Mouse":
                        animal = new Mouse(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
                        break;
                    case "Dog":
                        animal = new Dog(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
                        break;
                    case "Cat":
                        animal = new Cat(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
                        break;
                    case "Tiger":
                        animal = new Tiger(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
                        break;
                }
                string[] foodInfo = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Food food = null;
                string foodType = foodInfo[0];
                switch (foodType)
                {
                    case "Vegetable":
                        food = new Vegetable(int.Parse(foodInfo[1]));
                        break;
                    case "Fruit":
                        food = new Fruit(int.Parse(foodInfo[1]));
                        break;
                    case "Meat":
                        food = new Meat(int.Parse(foodInfo[1]));
                        break;
                    case "Seeds":
                        food = new Seeds(int.Parse(foodInfo[1]));
                        break;
                }
                try
                {
                    animal.Feed(food);
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                animals.Add(animal);
            }
            foreach (var animal in animals)
                writer.WriteLine(animal.ToString());
        }
    }
}
