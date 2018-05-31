import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P11_ExtractHyperLinks {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Pattern pattern = Pattern.compile("<a\\s+([^>]+\\s+)?href\\s*=\\s*('([^']*)'|\"([^\"]*)|([^\\s>]+))[^>]*>");

        String input = scanner.nextLine();
        StringBuilder builder = new StringBuilder();

        while (!input.equals("END")) {
            builder.append(input);
            input = scanner.nextLine();
        }

        List<String> matches = new ArrayList<>();
        Matcher matcher = pattern.matcher(builder.toString());

        while (matcher.find()) {
            String match = matcher.group(3);
            if (match == null) {
                match = matcher.group(4);
                if (match == null) {
                    match = matcher.group(5);
                    matches.add(match);
                } else {
                    matches.add(match);
                }
            } else {
                matches.add(match);
            }
        }

        matches.forEach(System.out::println);
    }

}
