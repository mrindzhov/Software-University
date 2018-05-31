package solutions.pr06RawData;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

class Engine {

    int speed;
    int power;

    Engine(int speed, int power) {
        this.speed = speed;
        this.power = power;
    }
}

class Cargo {

    int weight;
    String type;

    Cargo(int weight, String type) {
        this.type = type;
        this.weight = weight;
    }
}

class Tire {

    double pressure;
    int age;

    Tire(double pressure, int age) {
        this.pressure = pressure;
        this.age = age;
    }

}

class Car {

    String model;
    Engine engine;
    Cargo cargo;
    Tire[] tires;

    public Car(String model, int engineSpeed,
               int enginePower, int cargoWeight,
               String cargoType, double tire1Pressure,
               int tire1Age, double tire2Pressure,
               int tire2Age, double tire3Pressure, int tire3age,
               double tire4Pressure, int tire4age) {
        this.model = model;
        this.engine = new Engine(engineSpeed, enginePower);
        this.cargo = new Cargo(cargoWeight, cargoType);
        this.tires = new Tire[4];
        {
            this.tires[0] = new Tire(tire1Pressure, tire1Age);
            this.tires[1] = new Tire(tire2Pressure, tire2Age);
            this.tires[2] = new Tire(tire3Pressure, tire3age);
            this.tires[3] = new Tire(tire4Pressure, tire4age);
        }
    }
}

public class Pr06RawDataa {

    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        List<Car> cars = new ArrayList<>();
        int lines = Integer.parseInt(reader.readLine());
        for (int i = 0; i < lines; i++) {
            String[] parameters = reader.readLine().split("\\s+");
            String model = parameters[0];
            int engineSpeed = Integer.parseInt(parameters[1]);
            int enginePower = Integer.parseInt(parameters[2]);
            int cargoWeight = Integer.parseInt(parameters[3]);
            String cargoType = parameters[4];
            double tire1Pressure = Double.parseDouble(parameters[5]);
            int tire1age = Integer.parseInt(parameters[6]);
            double tire2Pressure = Double.parseDouble(parameters[7]);
            int tire2age = Integer.parseInt(parameters[8]);
            double tire3Pressure = Double.parseDouble(parameters[9]);
            int tire3age = Integer.parseInt(parameters[10]);
            double tire4Pressure = Double.parseDouble(parameters[11]);
            int tire4age = Integer.parseInt(parameters[12]);
            cars.add(new Car(model, engineSpeed, enginePower,
                    cargoWeight, cargoType, tire1Pressure,
                    tire1age, tire2Pressure, tire2age,
                    tire3Pressure, tire3age, tire4Pressure, tire4age));
        }

        String command = reader.readLine();
        if (command.equals("fragile")) {
            List<String> fragile = cars.stream()
                    .filter(x -> x.cargo.type.equals("fragile")
                            && Arrays.stream(x.tires)
                            .anyMatch(y -> y.pressure < 1))
                    .map(x -> x.model)
                    .collect(Collectors.toList());

            for (String fragileCarName : fragile) {
                System.out.printf("%s%n", fragileCarName);
            }
        } else {
            List<String> flamable = cars.stream()
                    .filter(x -> x.cargo.type.equals("flamable")
                            && x.engine.power > 250)
                    .map(x -> x.model)
                    .collect(Collectors.toList());

            for (String flamableCarName : flamable) {
                System.out.printf("%s%n", flamableCarName);
            }
        }
    }
}
