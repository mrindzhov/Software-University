package P02;

public class Car extends Vehicle{
    private final double SUMMER_FUEL_BONUS = 0.9;

    Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) {
        super(fuelQuantity, fuelConsumptionPerKm, tankCapacity);
    }


    @Override
    public void setFuelConsumptionPerKm(double fuelConsumptionPerKm) {
        super.setFuelConsumptionPerKm(fuelConsumptionPerKm+SUMMER_FUEL_BONUS);
    }
}
