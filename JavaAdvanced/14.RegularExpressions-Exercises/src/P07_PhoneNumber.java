import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedHashMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P07_PhoneNumber {

    public static void main(String[] args) throws IOException, IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        LinkedHashMap<String, String> phoneBook = new LinkedHashMap<>();

        Pattern pattern = Pattern.compile("([A-Z][a-zA-Z]*)(?:[^a-zA-Z+]*?)(\\+?\\d[\\d()./\\- ]*\\d)");

        StringBuilder text = new StringBuilder();

        String input;
        while (!"END".equals(input = reader.readLine()))
            text.append(input);

        Matcher matcher = pattern.matcher(text);

        while (matcher.find()) {
            String name = matcher.group(1);
            String number = matcher.group(2).replaceAll("[^+\\d]", "");

            phoneBook.put(name, number);
        }

        if (phoneBook.isEmpty()) {
            System.out.println("<p>No matches!</p>");
            return;
        }

        StringBuilder output = new StringBuilder("<ol>");
        for (String name : phoneBook.keySet()) {
            String number = phoneBook.get(name);
            output.append(String.format("<li><b>%s:</b> %s</li>", name, number));
        }
        output.append("</ol>");

        System.out.println(output);
    }
}