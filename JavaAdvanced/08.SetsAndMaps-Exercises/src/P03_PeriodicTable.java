import java.util.HashSet;
import java.util.LinkedHashSet;
import java.util.Scanner;
import java.util.TreeSet;

public class P03_PeriodicTable {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());
        TreeSet<String> set = new TreeSet<>();
        for (int i = 0; i < n; i++) {
            String[]input=sc.nextLine().split(" ");
            for (String s : input) {
                set.add(s);
            }
        }
        System.out.println(String.join(" ", set));
    }
}
