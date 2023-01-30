using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        private List<Car> cars;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            Cars = new List<Car>();
        }

        public List<Car> Cars { get { return cars; } set { cars = value; } }

        public int Count { get { return cars.Count; } }

        public string AddCar(Car car)
        {
            if(Cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if(Cars.Count >= capacity)
            {
                return "Parking is full!";
            }
            else
            {
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if(!Cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Cars.RemoveAll(x => x.RegistrationNumber == registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return Cars.First(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach(string registrationNumber in registrationNumbers)
            {
                Cars.RemoveAll(x => x.RegistrationNumber == registrationNumber);
            }
        }
    }
}
