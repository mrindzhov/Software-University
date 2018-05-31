package P05_PizzaCalories;


class Topping {
    private String type;
    private int weight;

    public Topping(String type, int weight) {
        this.setType(type);
        this.setWeight(weight);
    }

    public double getCalories() {
        final double BASE_CAL_PER_GRAM = 2.0;
        double mod = getMod();
        return this.weight * BASE_CAL_PER_GRAM * mod;
    }

    private void setType(String type) {
        if (!type.toLowerCase().equals("meat")
                && !type.toLowerCase().equals("veggies")
                && !type.toLowerCase().equals("cheese")
                && !type.toLowerCase().equals("sauce")) {
            throw new IllegalArgumentException(String.format("Cannot place %s on top of your pizza.", type));
        }

        this.type = type;
    }

    private void setWeight(int weight) {
        if (weight < 0 || weight > 50) {
            throw new IllegalArgumentException(String.format("%s weight should be in the range [1..50].", this.type));
        }
        this.weight = weight;
    }

    private double getMod() {
        final double MEAT_MOD = 1.2;
        final double VEGGIES_MOD = 0.8;
        final double CHEESE_MOD = 1.1;
        final double SAUCE_MOD = 0.9;

        double mod;

        switch (this.type.toLowerCase()) {
            case "meat":
                mod = MEAT_MOD;
                break;
            case "veggies":
                mod = VEGGIES_MOD;
                break;
            case "cheese":
                mod = CHEESE_MOD;
                break;
            case "sauce":
                mod = SAUCE_MOD;
                break;
            default:
                mod = 1.0;
        }

        return mod;
    }
}