import java.util.*;
import java.util.function.Consumer;
import java.util.function.UnaryOperator;
import java.util.stream.Collectors;

public class P05_AppliedArithmetic {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<Long> nums = Arrays.stream(scanner.nextLine().split(" ")).map(Long::parseLong).collect(Collectors.toList());
        String cmd = scanner.nextLine();
        while (!cmd.equals("end")) {
            switch (cmd) {
                case "add":
                    nums = filter(nums, x -> x + 1);
                    break;
                case "multiply":
                    nums = filter(nums, x -> x * 2);
                    break;
                case "subtract":
                    nums = filter(nums, x -> x - 1);
                    break;
                case "print":
                    applyConsumer(nums, x -> System.out.printf("%s ", x));
                    break;
            }
            cmd = scanner.nextLine();
        }
    }
    private static List<Long> filter(List<Long> numbers, UnaryOperator<Long> unaryOperator) {
        List<Long> output = new ArrayList<>();
        for (Long aLong : numbers) {
            output.add(unaryOperator.apply(aLong));

        }
        return output;
    }
    private static void applyConsumer(List<Long> numbers, Consumer<Long> consumer) {
        for (Long integer : numbers) {
            consumer.accept(integer);
        }
        System.out.println();
    }
}