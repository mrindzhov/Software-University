import java.util.*;

public class P02_SetsOfElements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] sets = scanner.nextLine().split(" ");
        LinkedHashSet<String> set1 = new LinkedHashSet<>();
        LinkedHashSet<String> set2 = new LinkedHashSet<>();

        for (int i = 0; i < Integer.parseInt(sets[0]); i++) {
            set1.add(scanner.nextLine());
        }
        for (int i = 0; i < Integer.parseInt(sets[1]); i++) {
            set2.add(scanner.nextLine());
        }
        set1.retainAll(set2);
        String joined=String.join(" ",set1);
        System.out.println(joined);
    }
}
