import java.util.Scanner;

public class P10_UnicodeCharacters {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        StringBuilder sb = new StringBuilder(sc.nextLine());
        for (char c : input.toCharArray()) {
            String hexFormat = Integer.toString((int) c, 16);
            int len = hexFormat.length();
            while (len < 4) {
                hexFormat = '0' + hexFormat;
                len = hexFormat.length();
            }
            sb.append(String.format("\\u%s", hexFormat));
        }
        System.out.println(sb);
    }
}
