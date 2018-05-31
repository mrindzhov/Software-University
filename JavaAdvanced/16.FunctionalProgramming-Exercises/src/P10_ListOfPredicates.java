import java.util.*;
import java.util.function.Predicate;

public class P10_ListOfPredicates {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Integer n = Integer.valueOf(sc.nextLine());
        List<Integer> range = new ArrayList<>();
        for (int i = 1; i <= n; i++) {
            range.add(i);
        }
        String[] numbers = sc.nextLine().split(" ");
        List<Predicate<Integer>> predicates = new ArrayList<>();
        for (String number : numbers) {
            Integer num = Integer.valueOf(number);
            predicates.add(x -> x % num == 0);
        }
        List<Integer> result = applyFilter(range, predicates);
        printResult(result);

    }

    private static List<Integer> applyFilter(List<Integer> range, List<Predicate<Integer>> predicates) {
        List<Integer> result = new ArrayList<>();
        for (Integer integer : range) {
            boolean filtered = false;
            for (Predicate<Integer> predicate : predicates) {
                if (!predicate.test(integer)) {
                    filtered = true;
                    break;
                }
            }
            if (!filtered) {
                result.add(integer);
            }
        }

        return result;
    }

    private static void printResult(List<Integer> result) {
        for (Integer currentString : result) {
            System.out.printf("%s ", currentString);
        }
    }
}
