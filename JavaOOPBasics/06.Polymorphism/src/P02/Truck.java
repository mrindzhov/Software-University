package P02;

public class Truck extends Vehicle {
    private final double SUMMER_FUEL_BONUS = 1.6;

    Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) {
        super(fuelQuantity, fuelConsumptionPerKm, tankCapacity);
    }


    @Override
    public void setFuelConsumptionPerKm(double fuelConsumptionPerKm) {
        super.setFuelConsumptionPerKm(fuelConsumptionPerKm + SUMMER_FUEL_BONUS);
    }

    @Override
    protected void refuel(double litres) {
        super.refuel(litres * 0.95);
    }
}