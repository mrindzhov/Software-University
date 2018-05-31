import java.util.Scanner;
import java.util.function.Predicate;

public class P07_PredicateForNames {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Integer length = Integer.valueOf(scanner.nextLine());
        String[] names = scanner.nextLine().split(" ");
        Predicate<String> checkLength = s -> s.length() <= length;
        for (String name : names) {
            if(checkLength.test(name))
            {
                System.out.println(name);
            }
        }
    }
}
