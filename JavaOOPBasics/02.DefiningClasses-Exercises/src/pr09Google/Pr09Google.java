package solutions.pr09Google;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;

class Company {

    String name;
    String deprartment;
    double salary;

    Company(String name, String department, double salary) {
        this.name = name;
        this.deprartment = department;
        this.salary = salary;
    }

    @Override
    public String toString() {
        return String.format("%s %s %.2f",
                this.name, this.deprartment, this.salary);
    }
}

class Car {

    String model;
    int speed;

    Car(String model, int speed) {
        this.model = model;
        this.speed = speed;
    }

    @Override
    public String toString() {
        return String.format("%s %d", this.model, this.speed);
    }
}

class Pokemon {

    String name;
    String element;

    Pokemon(String name, String element) {
        this.name = name;
        this.element = element;
    }

    @Override
    public String toString() {
        return String.format("%s %s", this.name, this.element);
    }
}

class Person {

    public String name;
    public String birthdate;

    public Person(String name, String birthdate) {
        this.name = name;
        this.birthdate = birthdate;
    }

    @Override
    public String toString() {
        return String.format("%s %s", this.name, this.birthdate);
    }
}

class PersonalInformation {

    String name;
    Company company;
    Car car;
    List<Person> parents;
    List<Person> children;
    List<Pokemon> pokemon;

    PersonalInformation(String name) {
        this.name = name;
        this.pokemon = new ArrayList<>();
        this.parents = new ArrayList<>();
        this.children = new ArrayList<>();
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(this.name).append(System.lineSeparator());
        sb.append("Company:").append(System.lineSeparator());
        if (this.company != null) {
            sb.append(String.format("%s %s %.2f%n",
                    this.company.name,
                    this.company.deprartment,
                    this.company.salary));
        }
        sb.append("Car:").append(System.lineSeparator());
        if (this.car != null) {
            sb.append(String.format("%s %d%n", this.car.model, this.car.speed));
        }
        sb.append("Pokemon:").append(System.lineSeparator());
        for (Pokemon currentPokemon : this.pokemon) {
            sb.append(currentPokemon.toString()).append(System.lineSeparator());
        }
        sb.append("Parents:").append(System.lineSeparator());
        for (Person parent : this.parents) {
            sb.append(parent.toString()).append(System.lineSeparator());
        }
        sb.append("Children:").append(System.lineSeparator());
        for (Person child : this.children) {
            sb.append(child.toString()).append(System.lineSeparator());
        }

        return sb.toString();
    }
}

public class Pr09Google {

    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        LinkedHashMap<String, PersonalInformation> informationDB = new LinkedHashMap<>();

        String line = reader.readLine();
        while (!line.equals("End")) {
            String[] parameters = line.split("\\s+");
            String name = parameters[0];
            if (!informationDB.containsKey(name)) {
                informationDB.put(name, new PersonalInformation(name));
            }
            PersonalInformation person = informationDB.get(name);
            if (parameters[1].equals("company")) {
                String company = parameters[2];
                String department = parameters[3];
                double salary = Double.parseDouble(parameters[4]);

                person.company = new Company(company, department, salary);
            } else if (parameters[1].equals("car")) {
                String model = parameters[2];
                int speed = Integer.parseInt(parameters[3]);

                person.car = new Car(model, speed);
            } else if (parameters[1].equals("parents")) {
                String parent = parameters[2];
                String birthdate = parameters[3];

                person.parents.add(new Person(parent, birthdate));
            } else if (parameters[1].equals("children")) {
                String child = parameters[2];
                String birthdate = parameters[3];

                person.children.add(new Person(child, birthdate));
            } else if (parameters[1].equals("pokemon")) {
                String pokemon = parameters[2];
                String element = parameters[3];

                person.pokemon.add(new Pokemon(pokemon, element));
            }

            line = reader.readLine();
        }

        line = reader.readLine();

        System.out.print(informationDB.get(line));
    }
}
