import java.util.ArrayDeque;
import java.util.Scanner;

public class P10_StackFibonacci {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.valueOf(scanner.nextLine());
        ArrayDeque<Long> fibb = new ArrayDeque<>();
        long asd=1;
        fibb.push(asd);
        fibb.push(asd);
        for (int i = 1; i <n ; i++) {
            long second=fibb.pop();
            long first=fibb.peek();
            fibb.push(second);
            fibb.push(first+second);
        }
        System.out.println(fibb.peek());
    }
}
