import java.util.Scanner;

public class TransportPrice {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int distance = Integer.valueOf(scanner.nextLine());
        String dayOrNight = scanner.nextLine();
        double taxiRate = 0.90;
        if (dayOrNight.equals("day")) {
            taxiRate = 0.79;
        }
        if (distance < 20) {
            System.out.printf("%.2f", 0.70 + (distance * taxiRate));
        }else if (distance < 100)
            System.out.printf("%.2f", distance * 0.09);
        else
            System.out.printf("%.2f", distance * 0.06);

    }
}
