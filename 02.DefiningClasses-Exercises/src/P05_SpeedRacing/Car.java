package P05_SpeedRacing;

import java.util.Locale;

public class Car {
    private String model;
    private double fuelAmount;
    private double fuelCost;
    private double distanceTravelled;

    Car(String model, Double fuelAmount, Double fuelCost) {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelCost = fuelCost;
        this.distanceTravelled = 0;
    }

    boolean CoverDistance(double distanceToTravel) {
        double neededFuel = distanceToTravel * this.fuelCost;
        if (neededFuel > fuelAmount) {
            return false;
        } else {
            setDistanceTravelled(distanceToTravel);
            this.fuelAmount -= neededFuel;
            return true;
        }
    }

    private void setDistanceTravelled(double distanceTravelled) {
        this.distanceTravelled += distanceTravelled;
    }

    public double getDistanceTravelled() {
        return distanceTravelled;
    }

    public double getFuelAmount() {
        return fuelAmount;
    }

    @Override
    public String toString() {
        return String.format(Locale.US,"%s %.2f %.0f", this.model, this.fuelAmount, this.distanceTravelled);
    }
}
