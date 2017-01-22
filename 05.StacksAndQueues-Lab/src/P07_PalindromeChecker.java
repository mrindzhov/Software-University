import java.util.ArrayDeque;
import java.util.Scanner;

public class P07_PalindromeChecker {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String palindromeCandidate = scanner.nextLine();
        ArrayDeque<Character> queue = new ArrayDeque<>();
        for (char c : palindromeCandidate.toCharArray()) {
            queue.offer(c);
        }
        boolean isPalindrome=true;
        while (queue.size() > 1) {
            if(!queue.poll().equals(queue.pollLast())){
                isPalindrome=false;
                break;
            }
        }
        System.out.println(isPalindrome);
    }
}
