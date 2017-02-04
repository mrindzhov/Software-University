import java.util.Scanner;

public class P09_TextFilter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] banList = scanner.nextLine().split(", ");
        String text = scanner.nextLine();
        for (String s : banList) {
            String filter = new String(new char[s.length()]).replace('\0', '*');
            text = text.replaceAll(s, filter);
        }
        System.out.println(text);
    }
}
