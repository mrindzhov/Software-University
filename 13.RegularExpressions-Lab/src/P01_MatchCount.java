import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P01_MatchCount {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String word = scanner.nextLine();
        String text = scanner.nextLine();
        Pattern pattern = Pattern.compile(word);
        Matcher matcher = pattern.matcher(text);
        int count=0;
        while (matcher.find()){
            count++;
        }
        System.out.println(count);
    }
}
