import java.util.HashSet;

import java.util.Scanner;

public class P01_ParkingLot {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        HashSet<String> cars = new HashSet<>();
        while (true) {
            String[] input = scanner.nextLine().split(", ");
            if (input[0].equals("END")) {
                if (cars.isEmpty()) {
                    System.out.println("Parking Lot is Empty");
                } else {
                    for (String car : cars) {
                        System.out.println(car);
                    }
                }
                break;
            }
            switch (input[0]) {
                case "IN":
                    cars.add(input[1]);
                    break;
                case "OUT":
                    cars.remove(input[1]);
                    break;
            }
        }
    }
}
