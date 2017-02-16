import java.io.IOException;
import java.util.*;
import java.util.function.Function;
import java.util.stream.Collectors;

/*
@FunctionalInterface
interface TriFunction<T1, T2, T3, TR> {

    public TR apply(T1 first, T2 second, T3 third);
}
*/

public class P15_TheBiggestOrSmallerInteger {

    public static void main(String[] args) throws IOException {

        Scanner scanner = new Scanner(System.in);
        List<Integer> integers = Arrays.stream(scanner.nextLine().split("[\\s]+")).map(Integer::parseInt).collect
                (Collectors.toList());
        String command = scanner.nextLine();

        Function<List<Integer>, Integer> findMin = (collection) -> {
            int minElement = Integer.MAX_VALUE;

            for (Integer integer : collection) {

                if (integer < minElement) {
                    minElement = integer;
                }
            }

            return minElement;
        };

        Function<List<Integer>, Integer> findMax = (collection) -> {
            int maxElement = Integer.MIN_VALUE;

            for (Integer integer : collection) {

                if (integer > maxElement) {
                    maxElement = integer;
                }
            }

            return maxElement;
        };


        TriFunction<Function<List<Integer>, Integer>, List<Integer>, Integer, Integer> triFunction =
                (function, collection, parity) -> {
                    List<Integer> buffer = new ArrayList<>();

                    for (Integer integer : collection) {
                        if (Math.abs(integer % 2) == parity) {
                            buffer.add(integer);
                        }
                    }

                    if (buffer.size() > 0) {
                        return function.apply(buffer);
                    }

                    return null;
                };

        Integer integer = 0;

        switch (command) {
            case "minEven":
                integer = triFunction.apply(findMin, integers, 0);
                break;
            case "maxEven":
                integer = triFunction.apply(findMax, integers, 0);
                break;
            case "minOdd":
                integer = triFunction.apply(findMin, integers, 1);
                break;
            case "maxOdd":
                integer = triFunction.apply(findMax, integers, 1);
                break;
        }

        System.out.println(integer == null ? "" : String.valueOf(integer));
    }
}