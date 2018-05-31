import java.util.LinkedHashSet;
import java.util.Scanner;

public class P01_UniqueUsernames {
    public static void main(String[] args) {
        Scanner scanner=new Scanner(System.in);
        int n =Integer.parseInt(scanner.nextLine());
        LinkedHashSet<String>names=new LinkedHashSet<>();
        for (int i = 0; i < n; i++) {
            String input=scanner.nextLine();
            names.add(input);
        }
        for (String name : names) {
            System.out.println(name);
        }
    }
}
