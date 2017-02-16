import java.util.*;
import java.util.function.Predicate;

public class P13_InfernoIII {
    private static Integer[] numbers;
    private static HashMap<String, HashMap<Integer, Predicate<Integer>>> filters;

    public static void main(String[] args) {
        // read input
        Scanner sc = new Scanner(System.in);
        String[] numbersInString = sc.nextLine().split("\\s+");
        numbers = new Integer[numbersInString.length];
        for (int i = 0; i < numbersInString.length; i++) {
            numbers[i] = Integer.valueOf(numbersInString[i]);
        }

        filters = new HashMap<>();

        while (true) {
            String line = sc.nextLine();
            if (line.equals("Forge")) {
                break;
            }

            String[] tokens = line.split(";");
            String command = tokens[0];
            String modifier = tokens[1];
            Integer variable = Integer.valueOf(tokens[2]);

            Predicate<Integer> predicate;
            if (command.equals("Exclude")) {
                predicate = buildPredicate(modifier, variable);
                if (!filters.containsKey(modifier)) {
                    filters.put(modifier, new HashMap<Integer, Predicate<Integer>>());
                }

                filters.get(modifier).put(variable, predicate);
            } else if (command.equals("Reverse")) {
                if (filters.containsKey(modifier)) {
                    if (filters.get(modifier).containsKey(variable)) {
                        filters.get(modifier).remove(variable);
                    }
                }
            }
        }

        List<Predicate<Integer>> predicates = getPredicatesList();
        for (int i = 0; i < numbers.length; i++) {
            boolean filter = false;
            for (Predicate<Integer> predicate : predicates) {
                if (predicate.test(i)) {
                    filter = true;
                }
            }

            if (!filter) {
                System.out.printf("%s ", numbers[i]);
            }
        }
    }

    private static Predicate<Integer> buildPredicate(String modifier, Integer variable) {
        switch (modifier) {
//            case "Square":
//                return x -> x * x == variable;
            case "Sum Left":
                return x -> (x - 1 < 0 ? 0 : numbers[x - 1]) + numbers[x] == variable;
            case "Sum Right":
                return x -> numbers[x] + (x + 1 >= numbers.length ? 0 : numbers[x + 1]) == variable;
            case "Sum Left Right":
                return x -> (x - 1 < 0 ? 0 : numbers[x - 1]) + numbers[x] + (x + 1 >= numbers.length ? 0 : numbers[x + 1]) == variable;
            default:
                return null;
        }
    }

    private static List<Predicate<Integer>> getPredicatesList () {
        List<Predicate<Integer>> predicates = new ArrayList<>();
        for (Map.Entry<String, HashMap<Integer, Predicate<Integer>>> entry : filters.entrySet()) {
            for (Map.Entry<Integer, Predicate<Integer>> innerEntry : entry.getValue().entrySet()) {
                predicates.add(innerEntry.getValue());
            }
        }

        return predicates;
    }
}