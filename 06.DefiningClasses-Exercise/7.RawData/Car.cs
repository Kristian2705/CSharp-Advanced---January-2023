using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car()
        {
            engine = new Engine();
            cargo = new Cargo();
            tires = new Tire[4];
        }

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1age, double tire2Pressure, int tire2age, double tire3Pressure, int tire3age, double tire4Pressure, int tire4age) : this()
        {
            this.Model= model;
            Engine.Speed = engineSpeed;
            Engine.Power = enginePower;
            Cargo.Weight = cargoWeight;
            Cargo.Type = cargoType;
            Tires = new Tire[4]
            {
                new Tire(tire1age, tire1Pressure),
                new Tire(tire2age, tire2Pressure),
                new Tire(tire3age, tire3Pressure),
                new Tire(tire4age, tire4Pressure),
            };
        }

        public string Model { get { return model; } set { model = value; } }
        public Engine Engine { get { return engine; } set { engine = value; } }

        public Cargo Cargo { get { return cargo; } set { cargo = value; } }
        public Tire[] Tires { get { return tires; } set { tires = value; } }
    }
}
