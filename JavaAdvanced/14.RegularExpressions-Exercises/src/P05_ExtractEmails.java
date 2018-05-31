import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P05_ExtractEmails {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String line = scanner.nextLine();
        StringBuilder stringBuilder = new StringBuilder();
        Pattern pattern = Pattern.compile("(?<= |^)([a-zA-Z0-9]+[a-zA-Z0-9_.-]?[a-zA-Z0-9]+)@" +
                "([a-zA-Z0-9]+-?[a-zA-Z0-9]+)(\\.[a-zA-Z0-9]+)+(?=[., ]|$)");

        while (!line.equals("end")) {
            Matcher matcher = pattern.matcher(line);

            while (matcher.find()) {
                stringBuilder.append(matcher.group()).append("\r\n");
            }

            line = scanner.nextLine();
        }

        System.out.println(stringBuilder.toString());
    }
}