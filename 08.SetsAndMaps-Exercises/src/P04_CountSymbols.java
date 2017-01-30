import java.util.Scanner;
import java.util.TreeMap;
import java.util.TreeSet;

public class P04_CountSymbols {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        TreeMap<Character, Integer> set = new TreeMap<>();
        for (char c : input.toCharArray()) {
            if(!set.containsKey(c)){
                set.put(c,1);
            }else{
                set.put(c,set.get(c)+1);
            }
        }
        for (Character character : set.keySet()) {
            System.out.println(character+": "+set.get(character)+" time/s");
        }
    }
}
