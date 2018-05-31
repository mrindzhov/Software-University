import java.util.*;
import java.util.function.Predicate;

public class P04_FindEvenOrOdds {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] integers = scanner.nextLine().split(" ");
        int i = Integer.parseInt(integers[0]);
        int j = Integer.parseInt(integers[1]);
        Integer[] numbers = new Integer[j - i + 1];

        for (int k = 0; k < numbers.length; k++) {
            numbers[k] = k + i;
        }
        String cmd = scanner.nextLine();
        if (cmd.equals("odd")) {
            filter(numbers, x -> x % 2 != 0);
        } else if (cmd.equals("even")) {
            filter(numbers, x -> x % 2 == 0);
        }
    }

    private static void filter(Integer[] numbers, Predicate<Integer> predicate) {
        for (Integer number : numbers) {
            if (predicate.test(number)){
                System.out.printf("%s ",number);
            }
        }
    }
}
