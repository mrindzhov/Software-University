package P05_PizzaCalories;

import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        try {
            String input = scanner.nextLine();

            while (!input.equals("END")) {
                String[] tokens = input.split("\\s+");

                switch (tokens[0]) {
                    case "Dough":
                        Dough dough = createDough(tokens);
                        System.out.printf("%.2f%n", dough.getCalories());
                        break;
                    case "Topping":
                        Topping topping = createTopping(tokens);
                        System.out.printf("%.2f%n", topping.getCalories());
                        break;
                    case "Pizza":
                        Pizza pizza = createPizza(tokens, scanner);
                        System.out.printf(Locale.US,"%s - %.2f%n", pizza.getName(), pizza.getCalories());
                        break;
                }

                input = scanner.nextLine();
            }
        } catch (IllegalArgumentException iae) {
            System.out.println(iae.getMessage());
        }
    }

    private static Pizza createPizza(String[] tokens, Scanner scanner) {
        String pizzaName = tokens[1];
        int numberOfToppings = Integer.valueOf(tokens[2]);

        Pizza pizza = new Pizza(pizzaName, numberOfToppings);

        String input = scanner.nextLine();
        String[] innerTokens = input.split("\\s+");

        Dough dough = createDough(innerTokens);
        pizza.setDough(dough);

        List<Topping> toppings = new ArrayList<>();
        for (int i = 0; i < pizza.getNumberOfToppings(); i++) {
            input = scanner.nextLine();
            innerTokens = input.split("\\s+");
            pizza.addTopping(createTopping(innerTokens));
        }

        return pizza;
    }

    private static Topping createTopping(String[] tokens) {
        return new Topping(tokens[1], Integer.valueOf(tokens[2]));
    }

    private static Dough createDough(String[] tokens) {
        return new Dough(tokens[1], tokens[2], Integer.valueOf(tokens[3]));
    }
}