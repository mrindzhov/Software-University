import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class P02_StringLength {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringBuilder sb = new StringBuilder(br.readLine());
        String star = "*";
        if (sb.length() < 20) {
            sb.append(new String(new char[20 - sb.length()]).replace("\0", star));

            System.out.println(sb);
        } else {
            System.out.println(sb.substring(0,20));
        }
    }
}
