import java.util.ArrayDeque;
import java.util.Collections;
import java.util.Scanner;

public class P05_HotPotato {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split("\\s+");
        int n = Integer.valueOf(scanner.nextLine());
        ArrayDeque<String> queue = new ArrayDeque<>();
        Collections.addAll(queue, input);
        while (queue.size() > 1) {
            for (int i = 1; i < n; i++) {
                String firstChild = queue.poll();
                queue.offer(firstChild);
            }
            System.out.println("Removed "+queue.poll());

        }
        System.out.println("Last is " + queue.poll());
    }
}
