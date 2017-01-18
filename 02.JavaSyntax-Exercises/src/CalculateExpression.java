import java.util.Scanner;

public class CalculateExpression {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double a = scanner.nextDouble();
        double b = scanner.nextDouble();
        double c = scanner.nextDouble();
        double f1power = (a + b + c) / Math.sqrt(c);
        double f1 = Math.pow((((a * a) + (b * b)) / ((a * a) - (b * b))), f1power);

        double f2power = a - b;
        double f2 = Math.pow(((a * a) + (b * b) - (c * c * c)), f2power);
        double diff = ((a + b + c) / 3) - ((f1 + f2) / 2);
        System.out.printf("F1 result: %.2f; F2 result: %.2f; Diff: %.2f", f1, f2, Math.abs(diff));
    }
}