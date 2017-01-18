import java.util.Scanner;

public class CharacterMultiplier {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] lineArgs = scanner.nextLine().split("\\s+");
        String first = lineArgs[0];
        String second = lineArgs[1];

        int min = Math.min(first.length(), second.length());
        long result = 0;
        for (int i = 0; i < min; i++) {
            result += first.charAt(i) * second.charAt(i);
        }

        String longer = first.length() > second.length() ? first : second;
        for (int i = min; i < longer.length(); i++) {
            result += longer.charAt(i);
        }

        System.out.println(result);
    }
}
