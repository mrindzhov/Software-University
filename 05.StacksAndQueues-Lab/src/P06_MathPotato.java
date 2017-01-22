import java.util.ArrayDeque;
import java.util.Collections;
import java.util.Scanner;

public class P06_MathPotato {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split("\\s+");
        int n = Integer.valueOf(scanner.nextLine());
        ArrayDeque<String> queue = new ArrayDeque<>();
        Collections.addAll(queue, input);
        int counter=1;

        while (queue.size() > 1) {
            for (int i = 1; i < n; i++) {
                String firstChild = queue.poll();
                queue.offer(firstChild);
            }
            if(isPrime(counter)){
                System.out.println("Prime " + queue.peek());
            }else {
                System.out.println("Removed " + queue.poll());
            }
            counter++;
        }
        System.out.println("Last is " + queue.poll());
    }

    private static boolean isPrime(int counter) {
        if (counter <= 1) {
            return false;
        }
        for (int i = 2; i <= Math.sqrt(counter); i++) {
            if(counter%i==0) {
                return false;
            }
        }
        return true;
    }

}
