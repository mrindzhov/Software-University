import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class FirstOddOrEvenElements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<Integer> numbers = Arrays.stream(scanner.nextLine()
                .split("\\s+"))
                .map(Integer::valueOf)
                .collect(Collectors.toList());

        String[] lineArgs = scanner.nextLine().split("\\s+");
        int count = Integer.valueOf(lineArgs[1]);
        int remainder = lineArgs[2].equals("even") ? 0 : 1;

        int index = 0;
        int printedCount = 0;
        while (index < numbers.size() && printedCount < count) {
            Integer current = numbers.get(index);
            if (Math.abs(current) % 2 == remainder) {
                System.out.print(current + " ");
                printedCount++;
            }
            index++;
        }
    }
}
