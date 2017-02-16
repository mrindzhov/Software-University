import java.util.*;
import java.util.function.BiFunction;
import java.util.stream.Collectors;

@FunctionalInterface
interface TriFunction<T1, T2, T3, TR> {

    public TR apply(T1 first, T2 second, T3 third);
}

public class P14_TriFunction {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        int targetAscii = Integer.valueOf(scanner.nextLine());
        List<String> names = Arrays.stream(scanner.nextLine().split("[\\s]+")).collect(Collectors.toList());

        BiFunction<String, Integer, Boolean> checkForAscii = (name, targetCode) -> {
            int totalSum = 0;

            for (int i = 0; i < name.length(); i++) {
                totalSum += name.charAt(i);
            }

            if (totalSum >= targetCode) {
                return true;
            }

            return false;
        };

        TriFunction<Integer, BiFunction<String, Integer, Boolean>, List<String>, String> findFirstOccurency =
                (targetCode, biFunction, collection) -> {
                    for (String name : collection) {
                        if (biFunction.apply(name, targetCode)) {
                            return name;
                        }
                    }

                    return "";
                };

        String result = findFirstOccurency.apply(targetAscii,checkForAscii,names);
        System.out.println(result);
    }
}