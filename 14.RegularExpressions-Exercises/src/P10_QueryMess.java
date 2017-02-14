import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P10_QueryMess {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String text = scanner.nextLine();

        while (!text.equals("END")) {
            Map<String, List<String>> query = new LinkedHashMap<>(); // Using a dictionary to store the pairs
            text = text.replaceAll(".+?(?=\\?)(\\?)+", "+");

            String[] pairs = extractPairs(text); // Using an array to process the pairs
            decodeWhiteSpaces(pairs); // Trim white spaces in the beginning and end of values
            reduceWhiteSpaces(pairs); // Reduce multiple white spaces to only one

            for (String pair1 : pairs) {
                String[] pair = Arrays.stream(pair1.split("=")).map(String::trim).toArray(String[]::new);
                if (!query.containsKey(pair[0])) {
                    List<String> container = new ArrayList<>();
                    container.add(pair[1]);
                    query.put(pair[0], container);
                } else {
                    query.get(pair[0]).add(pair[1]);
                }
            }

            for (Map.Entry<String, List<String>> entry : query.entrySet()) {
                System.out.printf("%s=[%s]", entry.getKey(), String.join(", ", entry.getValue()));
            }
            System.out.println();
            text = scanner.nextLine();
        }
    }

    private static void reduceWhiteSpaces(String[] pairs) {
        for (int i = 0; i < pairs.length; i++) {
            pairs[i] = pairs[i].replaceAll("[\\s]+", " ");
        }
    }

    private static void decodeWhiteSpaces(String[] pairs) {
        for (int i = 0; i < pairs.length; i++) {
            pairs[i] = pairs[i].replaceAll("(\\+|%20)", " ");
        }
    }

    private static String[] extractPairs(String text) {
        Pattern pattern = Pattern.compile("([^&?]+)=([^&?]*)"); // Match this pattern
        List<String> matches = new ArrayList<>();
        Matcher matcher = pattern.matcher(text);

        while (matcher.find()) {
            matches.add(matcher.group().trim() + "\r\n");
        }

        return matches.stream().toArray(String[]::new);
    }
}
