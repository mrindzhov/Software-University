import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayDeque;
import java.util.Arrays;
import java.io.IOException;

public class P01_ReverseNumbersWithStack {
    public static void main(String[] args) {
        BufferedReader Console = new BufferedReader(new InputStreamReader(System.in));
        try {
            Integer[] input = Arrays.stream(Console.readLine().split("\\s+"))
                    .map(Integer::parseInt)
                    .toArray(Integer[]::new);
            ArrayDeque<Integer>deque=new ArrayDeque<>();

            for (Integer integer : input) {
                deque.push(integer);
            }
            for (Integer integer : deque) {
                System.out.print(deque.pop()+" ");
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
