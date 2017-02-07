import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P07_ValidTime {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        Pattern pattern = Pattern.compile("^(\\d{2}):(\\d{2}):(\\d{2}) [AP]M$");
        String text = reader.readLine();
        while (!text.equals("END")) {
            Matcher matcher = pattern.matcher(text);
            if (matcher.find()) {
                if (isValidTime(matcher))
                    System.out.println("valid");
                else
                    System.out.println("invalid");
            } else {
                System.out.println("invalid");
            }
            text = reader.readLine();
        }
    }

    private static boolean isValidTime(Matcher matcher) {
        String[] split = matcher.group().split(":");
        if (Integer.valueOf(split[1]) >= 0 && Integer.valueOf(split[2].substring(0,split[2].length()-3)) >= 0 && Integer.valueOf(split[0]) > 0)
            if (Integer.valueOf(split[0]) < 13) {
                if (Integer.valueOf(split[1]) < 61) {
                    if (Integer.valueOf(split[2].substring(0,split[2].length()-3)) < 61) {
                        return true;
                    }
                }
            }
        return false;

    }
}