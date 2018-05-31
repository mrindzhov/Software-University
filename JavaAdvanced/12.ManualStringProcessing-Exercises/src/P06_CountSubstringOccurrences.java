import java.util.Scanner;

public class P06_CountSubstringOccurrences {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();
        String word = sc.nextLine().toLowerCase();
        int counter=0;
        for (int startIdx = 0; startIdx <= text.toCharArray().length-word.length(); startIdx++) {
            int endIdx=startIdx+word.length();
            if(word.equalsIgnoreCase(text.substring(startIdx, endIdx))){
                counter++;
            }
        }
        System.out.println(counter);
    }
}
