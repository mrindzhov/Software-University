import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P02_VowelCount {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        String text = reader.readLine();
        String vowels = "aeiouyAEIOUY";
        Pattern pattern = Pattern.compile("[aeiouyAEIOUY]");
        Matcher matcher=pattern.matcher(text);
        int count=0;
        while (matcher.find()){
            count++;
        }
        System.out.println("Vowels: " + count);
    }
}
