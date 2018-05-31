import java.util.*;

public class P02_BasicStackOperations {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] tokens = scanner.nextLine().split(" ");

        int n = Integer.parseInt(tokens[0]);
        int s = Integer.parseInt(tokens[1]);
        int x = Integer.parseInt(tokens[2]);

        String[] input = scanner.nextLine().split(" ");
        Integer[] numbers = Arrays.stream(input)
                .mapToInt(Integer::parseInt)
                .boxed()
                .toArray(Integer[]::new);
        ArrayDeque<Integer> operationList = new ArrayDeque<>();

        for (int i = 0; i < n; i++) {
            operationList.push(numbers[i]);
        }
        for (int i = 0; i < s; i++) {
            operationList.pop();
        }
        if (operationList.contains(x)) {
            System.out.println(true);
        } else {
            if (operationList.isEmpty()) {
                System.out.println(0);
                return;
            }
            System.out.println(Collections.min(operationList));
        }
    }
}
