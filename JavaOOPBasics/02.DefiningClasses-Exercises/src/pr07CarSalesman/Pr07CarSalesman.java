package solutions.pr07CarSalesman;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

class Engine {

    static final String OFFSET = "  ";

    String model;
    int power;
    int displacement;
    String efficiency;

    Engine(String model, int power) {
        this(model, power, -1, "n/a");
    }

    Engine(String model, int power, int displacement) {
        this(model, power, displacement, "n/a");
    }

    Engine(String model, int power, String efficiency) {
        this(model, power, -1, efficiency);
    }

    Engine(String model, int power, int displacement, String efficiency) {
        this.model = model;
        this.power = power;
        this.displacement = displacement;
        this.efficiency = efficiency;
    }


    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(String.format("%s%s:%n", OFFSET, this.model));
        sb.append(String.format("%s%sPower: %d\n", OFFSET, OFFSET, this.power));
        sb.append(String.format("%s%sDisplacement: %s\n", OFFSET, OFFSET, this.displacement == -1 ? "n/a" : this
                .displacement + ""));
        sb.append(String.format("%s%sEfficiency: %s\n", OFFSET, OFFSET, this.efficiency));

        return sb.toString();
    }
}

class Car {

    private static final String OFFSET = "  ";

    String model;
    Engine engine;
    int weight;
    String color;

    Car(String model, Engine engine) {
        this(model, engine, -1, "n/a");
    }

    Car(String model, Engine engine, int weight) {
        this(model, engine, weight, "n/a");
    }

    Car(String model, Engine engine, String color) {
        this(model, engine, -1, color);
    }

    Car(String model, Engine engine, int weight, String color) {
        this.model = model;
        this.engine = engine;
        this.weight = weight;
        this.color = color;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(String.format("%s:%n", this.model));
        sb.append(this.engine);
        sb.append(String.format("%sWeight: %s%n", OFFSET, this.weight == -1 ? "n/a" : this.weight + ""));
        sb.append(String.format("%sColor: %s", OFFSET, this.color));

        return sb.toString();
    }
}

public class Pr07CarSalesman {

    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        List<Car> cars = new ArrayList<>();
        List<Engine> engines = new ArrayList<>();
        int engineCount = Integer.parseInt(reader.readLine());
        for (int i = 0; i < engineCount; i++) {
            String[] parameters = reader.readLine().split("\\s+");
            String model = parameters[0];
            int power = Integer.parseInt(parameters[1]);

            int displacement = -1;

            if (parameters.length == 3) {
                try {
                    displacement = Integer.parseInt(parameters[2]);
                    engines.add(new Engine(model, power, displacement));
                } catch (NumberFormatException nfe) {
                    String efficiency = parameters[2];
                    engines.add(new Engine(model, power, efficiency));
                }
            } else if (parameters.length == 4) {
                String efficiency = parameters[3];
                engines.add(new Engine(model, power, Integer.parseInt(parameters[2]), efficiency));
            } else {
                engines.add(new Engine(model, power));
            }
        }
        int carCount = Integer.parseInt(reader.readLine());
        for (int i = 0; i < carCount; i++) {
            String[] parameters = reader.readLine().split("\\s+");
            String model = parameters[0];
            String engineModel = parameters[1];
            Engine engine = null;
            for (Engine eng : engines) {
                if (eng.model.equals(engineModel)) {
                    engine = eng;
                    break;
                }
            }

            int weight = -1;

            if (parameters.length == 3) {
                try {
                    weight = Integer.parseInt(parameters[2]);
                    cars.add(new Car(model, engine, weight));
                } catch (NumberFormatException nfe) {
                    String color = parameters[2];
                    cars.add(new Car(model, engine, color));
                }
            } else if (parameters.length == 4) {
                String color = parameters[3];
                cars.add(new Car(model, engine, Integer.parseInt(parameters[2]), color));
            } else {
                cars.add(new Car(model, engine));
            }
        }

        for (Car car : cars) {
            System.out.println(car);
        }
    }
}
