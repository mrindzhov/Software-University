import java.util.ArrayDeque;
import java.util.Scanner;

public class P08_BalancedParentheses {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();
        if (CheckParentesis(input)) {
            System.out.print("YES");
        } else {
            System.out.print("NO");
        }
    }

    public static boolean CheckParentesis(String str) {
        if (str.isEmpty())
            return true;

        ArrayDeque<Character> stack = new ArrayDeque<>();
        for (int i = 0; i < str.length(); i++) {
            char current = str.charAt(i);
            if (current == '{' || current == '(' || current == '[') {
                stack.push(current);
            }

            if (current == '}' || current == ')' || current == ']') {
                if (stack.isEmpty())
                    return false;

                char last = stack.peek();
                if (current == '}' && last == '{' || current == ')' && last == '(' || current == ']' && last == '[')
                    stack.pop();
                else
                    return false;
            }
        }

        return stack.isEmpty();
    }
}