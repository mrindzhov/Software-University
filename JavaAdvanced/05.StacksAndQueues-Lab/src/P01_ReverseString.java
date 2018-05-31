import java.util.ArrayDeque;
import java.util.Scanner;

public class P01_ReverseString {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input =scanner.nextLine();
        ArrayDeque<Character> stack=new ArrayDeque<>();
        for (char s  : input.toCharArray()) {
            stack.push(s);
        }
        for (Character character : stack) {
            System.out.print(character);
        }
    }
}