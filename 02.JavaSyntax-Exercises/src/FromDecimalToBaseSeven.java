import java.util.Scanner;

public class FromDecimalToBaseSeven {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number = Integer.valueOf(scanner.nextLine());
        System.out.println(convertFromBaseTenToBaseSeven(number));
    }

    private static String convertFromBaseTenToBaseSeven(int number) {

        StringBuilder builder = new StringBuilder();

        while (number != 0) {
            Integer remainder = number % 7;
            builder.append(remainder);
            number /= 7;
        }

        return builder.reverse().toString();
    }
}
