package P02;

import com.sun.javaws.exceptions.InvalidArgumentException;

import java.security.InvalidParameterException;
import java.text.DecimalFormat;
import java.util.Locale;

public abstract class Vehicle {
    private boolean hasPeople;

    private double tankCapacity;
    private double fuelQuantity;
    private double fuelConsumptionPerKm;
 //   private double distanceTravelled;

    Vehicle(double fuelQuantity, double fuelConsumptionPerKm,double tankCapacity) {
        setFuelQuantity(fuelQuantity);
        setFuelConsumptionPerKm(fuelConsumptionPerKm);
        setTankCapacity(tankCapacity);
    }
    public void setTankCapacity(double tankCapacity) {
        this.tankCapacity = tankCapacity;
    }
    private double getFuelConsumptionPerKm() {
        return fuelConsumptionPerKm;
    }

    public void setFuelConsumptionPerKm(double fuelConsumptionPerKm) {
        this.fuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    double getFuelQuantity() {
        return fuelQuantity;
    }

    private void setFuelQuantity(double value) {
        if (value > 0) {
            if (value + fuelQuantity > tankCapacity) {
                System.out.println("Cannot fit more fuel in tank");
//                throw new IllegalArgumentException("Cannot fit more fuel in tank");
            }
                this.fuelQuantity = value;
        }
        System.out.println(("Fuel must be positive number"));
//        throw new IllegalArgumentException("Fuel must be positive number").sout;
    }

//    private double getDistanceTravelled() {
//        return distanceTravelled;
//    }

   // private void setDistanceTravelled(double distanceTravelled) {
       //this.distanceTravelled += distanceTravelled;
    //}

    protected void refuel(double litres) {
        this.fuelQuantity += litres;
    }

    protected void drive(double distance) {
        if (getFuelConsumptionPerKm() * distance > getFuelQuantity()) {
            throw new InvalidParameterException(this.getClass().getSimpleName() + " needs refueling");
        }
       // setDistanceTravelled(distance);
        this.fuelQuantity -= distance * getFuelConsumptionPerKm();
        DecimalFormat df = new DecimalFormat("0.######");
        System.out.printf("%s travelled %s km%n", this.getClass().getSimpleName(), df.format(distance));
    }

    @Override
    public String toString() {
        return String.format(Locale.US, "%s: %.2f", this.getClass().getSimpleName(), getFuelQuantity());
    }


}