package P05_Animals;

import java.util.List;
import java.util.ArrayList;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        try {
            Scanner scanner = new Scanner(System.in);
            String animalKind = scanner.nextLine();
            List<Animal> animals = new ArrayList<>();

            while (!animalKind.equals("Beast!")) {
                String[] input = scanner.nextLine().split("[\\s]+");
                String name = input[0];
                int age = Integer.valueOf(input[1]);
                boolean isMale = false;

                if (input[2].equals("Male")) {
                    isMale = true;
                }
                try {
                    switch (animalKind) {
                        case "Dog":
                            animals.add(new Dog(name, age, isMale));
                            break;
                        case "Cat":
                            animals.add(new Cat(name, age, isMale));
                            break;
                        case "Frog":
                            animals.add(new Frog(name, age, isMale));
                            break;
                        case "Kitten":
                            animals.add(new Kitten(name, age));
                            break;
                        case "Tomcat":
                            animals.add(new Tomcat(name, age));
                            break;
                        default:
                            System.out.println("Invalid input!");
                            break;
                    }
                } catch (Exception e) {
                    System.out.println(e.getMessage());
                }

                animalKind = scanner.nextLine();
            }

            for (Animal animal : animals) {
                System.out.println(animal.toString() + animal.produceSound());
            }
        } catch (IllegalArgumentException exception) {
            System.out.println(exception.getMessage());
        }
    }
}