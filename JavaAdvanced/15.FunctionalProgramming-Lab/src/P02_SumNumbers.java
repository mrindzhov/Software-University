import java.util.*;
import java.util.function.Function;
import java.util.stream.Collectors;

public class P02_SumNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(", ");

        Function<String, Integer> parser = x -> Integer.parseInt(x);
        int sum = 0;
        for (String s : input) {
            sum += parser.apply(s);
        }
        System.out.println("Count = " + input.length);
        System.out.println("Sum = " + sum);

    }
}