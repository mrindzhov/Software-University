package P02;

public class Bus extends Vehicle {
    private final double SUMMER_FUEL_BONUS = 1.4;

    private boolean hasPeople;

    Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) {
        super(fuelQuantity, fuelConsumptionPerKm, tankCapacity);
    }


     public void setFuelConsumptionPerKm(double fuelConsumptionPerKm,boolean hasPeople) {
         if (hasPeople) {
             super.setFuelConsumptionPerKm(fuelConsumptionPerKm + SUMMER_FUEL_BONUS);
         }
     }
}