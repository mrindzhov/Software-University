import java.io.BufferedReader;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P04_ReplaceTag {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        StringBuilder text = new StringBuilder();
        String readLine = scanner.nextLine();

        while (!readLine.equals("END")) {
            text.append("\r\n").append(readLine);
            readLine = scanner.nextLine();
        }
        Pattern pattern = Pattern.compile("<a(\\s+href=[^>]+)>([^<]+)</a>");
        Matcher matcher = pattern.matcher(text.toString());

        while (matcher.find()) {
            int start = matcher.start();
            int end = matcher.end();
            String replacement = getReplacement(matcher);
            text.replace(start, end, replacement);
            matcher = pattern.matcher(text.toString());
        }
        System.out.println(text.toString().trim());
    }

    private static String getReplacement(Matcher matcher) {
        return "[URL" + matcher.group(1) + "]" + matcher.group(2) + "[/URL]";
    }
}
