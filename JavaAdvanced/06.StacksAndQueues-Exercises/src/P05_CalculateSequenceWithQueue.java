import java.util.ArrayDeque;
import java.util.Scanner;

public class P05_CalculateSequenceWithQueue {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        long number = Long.parseLong(scanner.nextLine());
        ArrayDeque<Long> sequence = new ArrayDeque<>();
        sequence.add(number);

        for (int i = 0; i < 50; i++) {
            long element = sequence.poll();
            System.out.printf("%d ", element);
            long s2 = element + 1;
            long s3 = element * 2 + 1;
            long s4 = element + 2;
            sequence.add(s2);
            sequence.add(s3);
            sequence.add(s4);
        }
    }
}
