import java.util.ArrayDeque;
import java.util.Scanner;

public class P03_DecimalToBinaryConverter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        long num = Long.parseLong(scanner.nextLine());
        ArrayDeque<Long> output = new ArrayDeque<>();
        if (num == 0) {
            System.out.println(0);
        }
        while (num != 0) {
            output.push(num % 2);
            num /= 2;
        }
        for (Long aLong : output) {
            System.out.print(aLong);
        }
    }
}
