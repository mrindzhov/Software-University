import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class OddAndEvenPairs {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<Integer> numbers = Arrays.stream(scanner.nextLine().split("\\s+"))
                .map(Integer::valueOf)
                .collect(Collectors.toList());

        if (numbers.size() % 2 != 0) {
            System.out.println("invalid length");
            return;
        }

        for (int i = 0; i < numbers.size(); i+=2) {
            int first = numbers.get(i);
            int second = numbers.get(i + 1);

            boolean isFirstEven = first % 2 == 0;
            boolean isSecondEven = second % 2 == 0;

            if ((isFirstEven && !isSecondEven) || (!isFirstEven && isSecondEven)) {
                System.out.printf("%s, %s -> different%n", first, second);
            }
            else if (isFirstEven && isSecondEven) {
                System.out.printf("%s, %s -> both are even%n", first, second);
            }
            else {
                System.out.printf("%s, %s -> both are odd%n", first, second);
            }
        }
    }
}
