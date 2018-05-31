import java.util.*;
import java.util.stream.Collectors;

public class P01_SortEvenNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<Integer> numbers = Arrays.stream(scanner.nextLine()
                .split(", "))
                .map(Integer::valueOf)
                .collect(Collectors.toList());
        StringBuilder sb = new StringBuilder();
        numbers.removeIf(n -> n % 2 != 0);
        for (Integer s : numbers) {
            sb.append(s);
            sb.append(", ");
        }
        sb.delete(sb.length() -2, sb.length());
        StringBuilder secondOutput = new StringBuilder()
                .append(sb)
                .append(System.lineSeparator());
        numbers.sort(Integer::compareTo);
        for (Integer number : numbers)
            secondOutput.append(number).append(", ");
        secondOutput.delete(secondOutput.length() - 2, secondOutput.length());

        System.out.println(secondOutput);
    }
}
