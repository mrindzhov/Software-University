import java.util.Scanner;

public class FormattingNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int a = scanner.nextInt();
        double b = scanner.nextDouble();
        double c = scanner.nextDouble();

        String binaryA = String.format("%10s", Integer.toBinaryString(a)).replace(' ', '0');
        System.out.printf("|%-10X|%s|%10.2f|%-10.3f|",a, binaryA, b, c);
    }
}
