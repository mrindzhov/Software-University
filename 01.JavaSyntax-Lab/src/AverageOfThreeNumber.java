import java.util.Scanner;

public class AverageOfThreeNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double first = scanner.nextDouble();
        double second = scanner.nextDouble();
        double third = scanner.nextDouble();
        double sumAbs = first + second + third;
        double avg = sumAbs / 3;
        System.out.printf("%.2f", avg);

    }
}
