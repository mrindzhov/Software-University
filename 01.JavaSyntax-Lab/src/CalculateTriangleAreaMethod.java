import java.util.Scanner;

public class CalculateTriangleAreaMethod {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        double width = input.nextDouble();
        double height = input.nextDouble();
        double area = calcTriangleArea(width, height);
        System.out.printf("Area = %.2f", area);

    }

    private static double calcTriangleArea(double width, double height) {
        return width * height / 2;

    }
}
