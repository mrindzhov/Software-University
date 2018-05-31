package P05_PizzaCalories;

import java.util.ArrayList;
import java.util.List;

class Pizza {
    private String name;
    private int numberOfToppings;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza(String name, int numberOfToppings) {
        this.setName(name);
        this.setNumberOfToppings(numberOfToppings);
        this.toppings = new ArrayList<>();
    }

    public String getName() {
        return this.name;
    }

    public int getNumberOfToppings() {
        return this.numberOfToppings;
    }

    public double getCalories() {
        double doughCalories = this.dough.getCalories();
        double toppingCalories = this.toppings
                .stream()
                .map(x -> x.getCalories())
                .reduce((x, y) -> x + y)
                .get();

        return doughCalories + toppingCalories;
    }

    public void addTopping(Topping topping) {
        this.toppings.add(topping);
    }

    public void setDough(Dough dough) {
        this.dough = dough;
    }

    private void setName(String name) {
        this.name = name;
    }

    private void setNumberOfToppings(int numberOfToppings) {
        if (numberOfToppings < 0 || numberOfToppings > 10) {
            throw new IllegalArgumentException("Number of toppings should be in range [0..10].");
        }

        this.numberOfToppings = numberOfToppings;
    }
}