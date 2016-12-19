using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.rawData
{
    class Car
    {
        public string model;
        public Engine engine;
        public Cargo cargo;
        public Tire[] tires;
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
        }
    }
    class Engine
    {
        public int speed;
        public int power;
        public Engine(int speed, int power)
        {
            this.speed = speed;
            this.power = power;
        }
    }
    class Cargo
    {
        public double weight;
        public string type;
        public Cargo(double weight, string type)
        {
            this.weight = weight;
            this.type = type;
        }
    }
    class Tire
    {
        public double pressure;
        public int age;
        public Tire(double pressure, int age)
        {
            this.pressure = pressure;
            this.age = age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine().Split(' ');
                string carModel = carInfo[0];

                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);

                double cargoWeight = double.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                double tirePressure = double.Parse(carInfo[5]);
                int tireAge = int.Parse(carInfo[6]);
                double tirePressure2 = double.Parse(carInfo[7]);
                int tireAge2 = int.Parse(carInfo[8]);
                double tirePressure3 = double.Parse(carInfo[9]);
                int tireAge3 = int.Parse(carInfo[10]);
                double tirePressure4 = double.Parse(carInfo[11]);
                int tireAge4 = int.Parse(carInfo[12]);
                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var tires = new Tire[4];
                tires[0] = new Tire(tirePressure, tireAge);
                tires[1] = new Tire(tirePressure2, tireAge2);
                tires[2] = new Tire(tirePressure3, tireAge3);
                tires[3] = new Tire(tirePressure4, tireAge4);
                var car = new Car(carModel, engine, cargo, tires);
                cars.Add(car);
            }
            string cargoTypeForPrint = Console.ReadLine();
            var sortedCars = new List<Car>();
            if (cargoTypeForPrint == "fragile")
            {
                sortedCars = cars
                    .Where(c => c.cargo.type == "fragile" &&
                        c.tires.Any(t => t.pressure < 1)).ToList();
            }
            else
            {
                sortedCars = cars
                    .Where(c => c.cargo.type == "flamable" &&
                            c.engine.power > 250).ToList();
            }
            foreach (var sortedCar in sortedCars)
            {
                Console.WriteLine(sortedCar.model);
            }
        }
    }
}
