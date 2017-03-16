package P02;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
          String[] carInput = reader.readLine().split(" ");
           double carFuelQuantity = Double.parseDouble(carInput[1]);
           double carFuelConsumption = Double.parseDouble(carInput[2]);
           double carTankCapacity = Double.parseDouble(carInput[3]);
           Car car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);
           String[] truckInput = reader.readLine().split(" ");
           double truckFuelQuantity = Double.parseDouble(truckInput[1]);
           double truckFuelConsumption = Double.parseDouble(truckInput[2]);
           double truckTankCapacity = Double.parseDouble(carInput[3]);
           Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

           String[] busInput = reader.readLine().split(" ");
           double busFuelQuantity = Double.parseDouble(busInput[1]);
           double busFuelConsumption = Double.parseDouble(busInput[2]);
           double busTankCapacity = Double.parseDouble(busInput[3]);
           Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

        int tests = Integer.parseInt(reader.readLine());
        for (int t = 0; t < tests; t++) {
            String[] command = reader.readLine().split(" ");
            String action = command[0];
            String vehicle = command[1];

            try {
                switch (vehicle) {
                    case "Car":
                        ExecuteCommand(car, action, command[2]);
                        break;
                    case "Truck":
                        ExecuteCommand(truck, action, command[2]);
                        break;
                    case "Bus":
                        ExecuteCommand(bus, action, command[2]);
                        break;
                    default:
                        break;
                }
            } catch (IllegalArgumentException iae) {
                System.out.println(iae.getMessage());
            }
        }

        System.out.printf("Car: %.2f%n", car.getFuelQuantity());
        System.out.printf("Truck: %.2f%n", truck.getFuelQuantity());
        System.out.printf("Bus: %.2f%n", bus.getFuelQuantity());

    }

    private static void ExecuteCommand(
            Vehicle vehicle, String action, String parameter) {
        switch (action) {
            case "Drive":
                double distance = Double.parseDouble(parameter);
                vehicle.drive(distance);
                break;
            case "Refuel":
                double liters = Double.parseDouble(parameter);
                vehicle.refuel(liters);
                break;
            case "DriveEmpty":
                double busDistance = Double.parseDouble(parameter);

                vehicle.drive(busDistance);
                break;
            default:
                break;
        }
    }
}

