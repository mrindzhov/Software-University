import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P03_SeriesOfLetters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        String pattern = "([a-zA-Z ])\\1*";

        Pattern regex = Pattern.compile(pattern);
        Matcher matcher = regex.matcher(input);

        while (matcher.find()) {
            System.out.print(matcher.group(1));
        }
    }
}