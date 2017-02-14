import java.util.Scanner;
import java.util.regex.Pattern;

public class P01_MatchFullName {
    public static void main(String[] args) {
        String regex = "[A-Z][a-z]+ [A-Z][a-z]+";

        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();

        while (!text.equals("end")) {
            if (Pattern.matches(regex, text)) {
                System.out.println(text);
            }

            text = sc.nextLine();
        }
    }
}
