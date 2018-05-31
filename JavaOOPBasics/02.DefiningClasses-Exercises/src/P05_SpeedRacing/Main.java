package P05_SpeedRacing;

import java.util.LinkedHashMap;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int carsCount = Integer.parseInt(scanner.nextLine());
        LinkedHashMap<String, Car> carList = new LinkedHashMap<>();
        for (int i = 0; i < carsCount; i++) {
            String[] input = scanner.nextLine().split(" ");
            String carModel = input[0];
            Double fuelAmount = Double.parseDouble(input[1]);
            Double fuelCost = Double.parseDouble(input[2]);
            Car car = new Car(carModel, fuelAmount, fuelCost);
            carList.put(carModel, car);
        }
        while (true) {
            String[] input = scanner.nextLine().split(" ");
            if (input[0].equals("End")) {
                break;
            }
            String carModel = input[1];
            Double distanceToTravel = Double.parseDouble(input[2]);
            if(!carList.get(carModel).CoverDistance(distanceToTravel)){
                System.out.println("Insufficient fuel for the drive");
            }
        }
        for (String s : carList.keySet()) {
            System.out.println(carList.get(s).toString());
        }
    }
}