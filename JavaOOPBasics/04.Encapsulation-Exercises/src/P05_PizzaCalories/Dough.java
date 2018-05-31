package P05_PizzaCalories;

import java.util.Locale;

class Dough {
    private String flourType;
    //white or wholegrain
    private String bakingTechnique;
    //crispy, chewy or homemade
    private Integer weight;
    //in grams
    private Double calories;
    //2 calories per gram as a base
    //modifiers for type of dough -

    // formula = (weight*2)*bakingTechnique*flourType
    //only public getter for the calories
    public Dough(String flourType, String bakingTechnique, Integer weight) {
        setFlourType(flourType);
        setBakingTechnique(bakingTechnique);
        setWeight(weight);
        setCalories();
    }

    private void setBakingTechnique(String bakingTechnique) {
        if (bakingTechnique.equalsIgnoreCase("crispy")
                || bakingTechnique.equalsIgnoreCase("homemade")
                || bakingTechnique.equalsIgnoreCase("chewy")) {
            this.bakingTechnique = bakingTechnique.toLowerCase();
        } else {
            throw new IllegalArgumentException("Invalid type of dough.");
        }
    }

    private void setFlourType(String flourType) {
        if (flourType.equalsIgnoreCase("white") || flourType.equalsIgnoreCase("wholegrain")) {
            this.flourType = flourType.toLowerCase();
        }else{
            throw new IllegalArgumentException("Invalid type of dough.");
        }
    }

    private void setWeight(Integer weight) {
        if (weight > 200 || weight < 1) {
            throw new IllegalArgumentException("Dough weight should be in the range [1..200].");
        } else {
            this.weight = weight;
        }
    }

    private void setCalories() {
        double bakingTechCal=0;
        double flourTypeCal=0;
        switch (bakingTechnique) {
            case "crispy":
                bakingTechCal = 0.9;
                break;
            case "homemade":
                bakingTechCal = 1.0;
                break;
            case "chewy":
                bakingTechCal = 1.1;
                break;
        }
        switch (flourType) {
            case "wholegrain":
                flourTypeCal = 1.0;
                break;
            case "white":
                flourTypeCal = 1.5;
                break;
        }
        this.calories = (2 * weight) * bakingTechCal * flourTypeCal;
    }

    public Double getCalories() {
        return calories;
    }
}
