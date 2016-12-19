using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.speedRacing
{
    public class Car
    {
        public string model;
        public decimal fuel;
        public decimal fuelConsumption;
        public decimal distanceTravelled;
        public Car(string model, decimal fuel, decimal fuelConsumption)
        {
            this.model = model;
            this.fuel = fuel;
            this.fuelConsumption = fuelConsumption;
            this.distanceTravelled = 0;
        }
        public void Drive(decimal amountOfKm)
        {
            if (amountOfKm <= this.fuel / this.fuelConsumption)
            {
                this.distanceTravelled += amountOfKm;
                this.fuel -= this.fuelConsumption * amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var garage = new List<Car>();
            for (int i = 0; i < count; i++)
            {
                var carInfo = Console.ReadLine().Split(' ');
                var car = new Car(carInfo[0], decimal.Parse(carInfo[1]), decimal.Parse(carInfo[2]));
                garage.Add(car);
            }
            while (true)
            {
                var input = Console.ReadLine().Split(' ');
                if (input[0] != "Drive")
                {
                    break;
                }
                var carModel = input[1];
                var amountOfKm = decimal.Parse(input[2]);
                var carToDrive = garage.First(c => c.model == carModel);
                carToDrive.Drive(amountOfKm);
            }
            foreach (var car in garage)
            {
                Console.WriteLine($"{car.model} {car.fuel:F2} {car.distanceTravelled}");
            }
        }
    }
}
