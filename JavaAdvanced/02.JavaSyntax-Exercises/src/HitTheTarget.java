import java.util.Scanner;

public class HitTheTarget {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int target = scanner.nextInt();
        for (int first = 1; first <= 20; first++) {
            for (int second = 1; second <= 20; second++) {
                if (first + second == target) {
                    System.out.printf("%s + %s = %s%n", first, second, target);
                }

                if (first - second == target) {
                    System.out.printf("%s - %s = %s%n", first, second, target);
                }
            }
        }
    }
}