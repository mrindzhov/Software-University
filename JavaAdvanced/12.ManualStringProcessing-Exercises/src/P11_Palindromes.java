import java.text.Collator;
import java.util.*;

public class P11_Palindromes {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] words = sc.nextLine().split("\\W+");
        ArrayList<String> palindromes=new ArrayList<>();
        for (String word : words)
        {
            StringBuilder reversedWord = new StringBuilder();
            for (int i = word.length() - 1; i >= 0; i--)
            {
                reversedWord.append(word.charAt(i));
            }
            if (word.equals(reversedWord.toString()) && !palindromes.contains(word))
            {
                palindromes.add(word);
            }
        }
        Collator usCollator = Collator.getInstance(Locale.US);
        usCollator.setStrength(Collator.FULL_DECOMPOSITION);
        Collections.sort(palindromes, usCollator);
        System.out.println(palindromes);
    }
}
