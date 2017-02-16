import java.util.*;
import java.util.function.Predicate;

public class P11_PredicateParty {
    private static List<String> names;
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split("\\s+");
        names = Arrays.asList(input);
        String cmd = scanner.nextLine();

        while (!cmd.equals("Party!")) {
            String[] tokens = cmd.split("\\s+");
            Predicate<String> predicate =buildPredicate(tokens[1],tokens[2]);
            if (tokens[0].equals("Double")) {
                doubleIf(predicate);
            } else if (tokens[0].equals("Remove")) {
                removeIf(predicate);
            }
            cmd = scanner.nextLine();

        }

        if (names.size() != 0) {
            System.out.println(String.join(", ", names) + " are going to the party!");
        } else {
            System.out.println("Nobody is going to the party!");
        }

    }

    private static void removeIf(Predicate<String> predicate) {
        List<String>guests=new ArrayList<>();
        for (String name : names) {
            if(!predicate.test(name)) {
                guests.add(name);
            }
        }
        names=guests;
    }
    private static void doubleIf(Predicate<String> predicate) {
        List<String>guests=new ArrayList<>();
        for (String name : names) {
            if(predicate.test(name)) {
                guests.add(name);
            }
            guests.add(name);
        }
        names=guests;
    }

    private static Predicate<String> buildPredicate(String command, String variable)
    {
        switch (command) {
            case "StartsWith":
                return x -> x.startsWith(variable);
            case "EndsWith":
                return x -> x.endsWith(variable);
            case "Length":
                return x -> x.length() == Integer.valueOf(variable);
            default:
                return null;
        }
    }
}
