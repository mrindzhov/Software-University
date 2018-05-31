import java.util.Scanner;

public class TriangleArea {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] firstPointArgs = scanner.nextLine().split("\\s+");
        double aX = Double.valueOf(firstPointArgs[0]);
        double aY = Double.valueOf(firstPointArgs[1]);

        String[] secondPointArgs = scanner.nextLine().split("\\s+");
        double bX = Double.valueOf(secondPointArgs[0]);
        double bY = Double.valueOf(secondPointArgs[1]);

        String[] thirdPointArgs = scanner.nextLine().split("\\s+");
        double cX = Double.valueOf(thirdPointArgs[0]);
        double cY = Double.valueOf(thirdPointArgs[1]);

        double area = Math.abs((aX * (bY - cY) + bX * (cY - aY) + cX * (aY - bY)) / 2);
        System.out.println((int)area);
    }
}