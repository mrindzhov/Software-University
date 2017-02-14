import java.util.Scanner;
        import java.util.regex.Pattern;

public class P02_MatchPhoneNumber {
    public static void main(String[] args) {
        String regex = "\\+359([ -])2\\1\\d{3}\\1\\d{4}";
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();

        while (! text.equals("end")) {
            if (Pattern.matches(regex, text)) {
                System.out.println(text);
            }

            text = sc.nextLine();
        }
    }
}
