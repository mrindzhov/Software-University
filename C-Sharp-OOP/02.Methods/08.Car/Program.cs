using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Car
{
    private long speed;
    private long fuel;
    private long fuelEconomy;
    private long travelDistance;
    private long travelTime;
    public Car(long speed, long fuel, long fuelEconomy)
    {
        this.speed = speed;
        this.fuel = fuel;
        this.fuelEconomy = fuelEconomy;
    }
    public long Speed
    {
        get
        {
            return this.speed;
        }
        private set
        {
            this.speed = value;
        }
    }
    public long Fuel
    {
        get
        {
            return this.fuel;
        }
        private set
        {
            this.fuel = value;
        }
    }
    public long FuelEconomy
    {
        get
        {
            return this.fuelEconomy;
        }

        private set
        {
            this.fuelEconomy = value;
        }
    }
    public long TravelDistance
    {
        get
        {
            return this.travelDistance;
        }

        private set
        {
            this.travelDistance = value;
        }
    }
    public long TravelTime
    {
        get
        {
            return this.travelTime;
        }

        private set
        {
            this.travelTime = value;
        }
    }
    public void Travel(long distance)
    {
        long possibleTravelDistance = (this.fuel / this.fuelEconomy) * 100;
        long fuelConsumed = 0;
        long time = 0;
        if (possibleTravelDistance > distance)
        {
            this.TravelDistance += distance;
            fuelConsumed = (distance / 100) * this.fuelEconomy;
            time = (distance / this.Speed) * 60;
            this.TravelTime += time;
            this.Fuel -= fuelConsumed;
        }
        else
        {
            this.TravelDistance += possibleTravelDistance;
            time = (possibleTravelDistance / this.Speed) * 60;
            this.TravelTime += time;
            this.Fuel = 0;
        }
    }
    public void Refuel(long litres)
    {
        this.Fuel += litres;
    }
}

class Program
{
    static void Main()
    {
        string[] carDetails = Console.ReadLine().Split(' ');

        long speed = long.Parse(carDetails[0]);
        long fuel = long.Parse(carDetails[1]);
        long fuelEconomy = long.Parse(carDetails[2]);

        var car = new Car(speed, fuel, fuelEconomy);

        

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "END")
            {
                break;
            }

            string[] command = input.Split(' ');

            if (command.Length > 1)
            {
                if (command[0] == "Travel")
                {
                    string commandTravel = command[0];
                    long kilometersToTravel = long.Parse(command[1]);

                    car.Travel(kilometersToTravel);
                }
                else
                {
                    string commandRefuel = command[0];
                    long litersToRefuel = long.Parse(command[1]);

                    car.Refuel(litersToRefuel);
                }

            }
            else
            {
                if (input == "Distance")
                {
                    Console.WriteLine("Total distance: {0:F1} kilometers", car.TravelDistance);
                }
                else if (input == "Time")
                {
                    Console.WriteLine("Total time: {0} hours and {1} minutes", car.TravelTime / 60, car.TravelTime % 60);
                }
                else if (input == "Fuel")
                {
                    Console.WriteLine("Fuel left: {0:F1} liters", car.Fuel);
                }

            }

        }
    }
}
