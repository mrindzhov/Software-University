import java.util.ArrayList;
import java.util.Scanner;
import java.util.function.Function;
import java.util.function.Predicate;

public class P03_CountUpperCaseWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");

        Predicate<String> parser = s -> s.charAt(0) == s.toUpperCase().charAt(0);
        ArrayList<String> result = new ArrayList<>();
        for (String s : input) {
            if (parser.test(s)) {
                result.add(s);
            }
        }
        System.out.println(result.size());
        for (String s : result) {
            System.out.println(s);
        }
    }
}