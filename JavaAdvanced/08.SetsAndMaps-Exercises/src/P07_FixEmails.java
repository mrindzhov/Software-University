import java.util.LinkedHashMap;
import java.util.Scanner;

public class P07_FixEmails {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        LinkedHashMap<String, String> resources = new LinkedHashMap<>();
        while (true) {
            String name = scanner.nextLine();
            if (name.equals("stop")) {
                break;
            }
            String email = scanner.nextLine();
            if (email.endsWith("us") || email.endsWith("com") || email.endsWith("uk")) {
                resources.remove(email);
            } else {
                resources.put(name, email);
            }
        }
        for (String s : resources.keySet()) {
            System.out.println(s + " -> " + resources.get(s));
        }
    }
}
