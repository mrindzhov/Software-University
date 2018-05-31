import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Scanner;

public class P04_SpecialWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] words = scanner.nextLine().split(" ");
        HashMap<String, Integer> counter = new HashMap<>();
        String[] text = scanner.nextLine().split(" ");
        for (int i = 0; i < words.length; i++) {
            counter.put(words[i], 0);
            for (int j = 0; j < text.length; j++) {
                if (words[i].equals(text[j])) {
                    counter.put(words[i], counter.get(words[i]) + 1);
                }
            }
        }
        for (String s : counter.keySet()) {
            System.out.println(s+" - "+counter.get(s));
        }
    }
}
