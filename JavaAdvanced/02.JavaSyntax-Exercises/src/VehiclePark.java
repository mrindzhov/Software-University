import java.util.Arrays;
import java.util.LinkedList;
import java.util.Scanner;
import java.util.stream.Collectors;

public class VehiclePark {
    public static void main(String[] args) {
        Scanner scanner=new Scanner(System.in);
        LinkedList<String> vehicles = Arrays.stream(scanner.nextLine().split("\\s+"))
                .collect(Collectors.toCollection(LinkedList::new));
        int initialCount = vehicles.size();

        String line = "";
        while (!(line = scanner.nextLine()).equals("End of customers!")) {
            String[] lineArgs = line.split("\\s+");
            Character vehicleType = Character.toLowerCase(lineArgs[0].charAt(0));
            Integer seatCount = Integer.valueOf(lineArgs[2]);

            boolean isVehicleForSelling = false;

            String vehicle = String.valueOf(vehicleType) + seatCount.toString();
            for (int i = 0; i < vehicles.size(); i++) {
                if (vehicle.equals(vehicles.get(i))) {
                    System.out.printf("Yes, sold for %s$%n", getVehiclePrice(vehicleType, seatCount));
                    vehicles.remove(i);
                    isVehicleForSelling = true;
                    break;
                }
            }

            if (!isVehicleForSelling) {
                System.out.println("No");
            }
        }

        System.out.printf("Vehicles left: %s%n", vehicles.toString().substring(1, vehicles.toString().length() - 1));
        System.out.printf("Vehicles sold: %s", initialCount - vehicles.size());
    }

    private static long getVehiclePrice(Character vehicleType, int seatCount) {
        return vehicleType * seatCount;
    }
}
