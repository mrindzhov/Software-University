import java.util.ArrayDeque;
import java.util.Collections;
import java.util.Scanner;

public class P02_SimpleCalculator {
    public static void main(String[] args) {
        Scanner scanner=new Scanner(System.in);
        ArrayDeque<String>stack=new ArrayDeque<>();
        String[]input=scanner.nextLine().split("\\s+");
        Collections.addAll(stack,input);
        while(stack.size()>1){
            int first=Integer.parseInt(stack.pop());
            String operator=stack.pop();
            int second=Integer.parseInt(stack.pop());
            switch (operator) {
                case "+":
                    stack.push(String.valueOf(first+second));
                    break;
                case "-":
                    stack.push(String.valueOf(first-second));
                    break;
            }
        }
        System.out.println(stack.pop());
    }
}
