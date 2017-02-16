import java.util.*;
import java.util.function.Predicate;

/**
 * Read a list of strings and until you get a print command apply or remove filters to it
 */

public class P12_ThePartyReservationFilterModule {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        List<String> strings = Arrays.asList(sc.nextLine().split("\\s+"));
        HashMap<String, HashMap<String, Predicate<String>>> filters = new HashMap<>();

        String line = sc.nextLine();

        while (!line.equals("Print")) {
            String[] tokens = line.split(";");
            String command = tokens[0];
            String modifier = tokens[1];
            String variable = tokens[2];

            Predicate<String> filter = createPredicate(modifier, variable);

            if (command.equals("Add filter")) {
                if (!filters.containsKey(modifier)) {
                    filters.put(modifier, new HashMap<>());
                }

                filters.get(modifier).put(variable, filter);
            } else if (command.equals("Remove filter")) {
                if (filters.containsKey(modifier)) {
                    if (filters.get(modifier).containsKey(variable)) {
                        filters.get(modifier).remove(variable);
                    }
                }
            }

            line = sc.nextLine();
        }

        List<String> result = filter(strings, filters);
        printResult(result);
    }

    private static Predicate<String> createPredicate(String modifier, String variable) {
        switch (modifier) {
            case "Starts with":
                return x -> x.startsWith(variable);
            case "Ends with":
                return x -> x.endsWith(variable);
            case "Length":
                return x -> x.length() == Integer.valueOf(variable);
            case "Contains":
                return x -> x.contains(variable);
            default:
                return null;
        }
    }

    private static List<String> filter(List<String> strings, HashMap<String, HashMap<String, Predicate<String>>> filters) {
        List<String> result = new ArrayList<>();
        for (String currentString : strings) {
            boolean filtered = false;
            for (Map.Entry<String, HashMap<String, Predicate<String>>> entry : filters.entrySet()) {
                for (Map.Entry<String, Predicate<String>> innerEntry : entry.getValue().entrySet()) {
                    Predicate<String> filter = innerEntry.getValue();
                    if (filter.test(currentString)) {
                        filtered = true;
                        break;
                    }
                }
            }

            if (!filtered) {
                result.add(currentString);
            }
        }

        return result;
    }

    private static void printResult(List<String> result) {
        for (String currentString : result) {
            System.out.printf("%s ", currentString);
        }
    }
}