import java.util.*;

public class P15_PoisonousPlants {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        int[] plants = Arrays.stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();


        Stack<Integer> proximityStack = new Stack<>();
        int[] days = new int[plants.length];
        proximityStack.push(0);
        for (int x = 1; x < plants.length; x++) {
            int maxDays = 0;
            while (proximityStack.size() > 0 && plants[proximityStack.peek()] >= plants[x]) {

                maxDays = Integer.max(days[proximityStack.pop()], maxDays);
            }

            if (proximityStack.size() > 0) {
                days[x] = maxDays + 1;
            }

            proximityStack.push(x);
        }

        System.out.printf("%d%n", Arrays.stream(days).reduce((a, b) -> Math.max(b, a)).getAsInt());
    }

}

