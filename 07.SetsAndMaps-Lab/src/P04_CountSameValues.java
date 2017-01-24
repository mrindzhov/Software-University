import java.util.HashMap;
import java.util.Scanner;

public class P04_CountSameValues {
    public static void main(String[] args) {
        Scanner scanner=new Scanner(System.in);
        String[]input=scanner.nextLine().split(" ");
        HashMap<String,Integer>occurrences=new HashMap<>();
        for (String s : input) {
            if (occurrences.containsKey(s)) {
                occurrences.put(s, occurrences.get(s) + 1);
            } else {
                occurrences.put(s, 1);
            }
        }
        for (String s : occurrences.keySet()) {
            System.out.println(s+" - "+occurrences.get(s)+" times");
        }
    }
}
