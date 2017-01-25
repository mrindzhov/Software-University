import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Stack;

public class P14_StockSpan {

    public static void main(String[] args) throws IOException {
        BufferedReader scanner = new BufferedReader(new InputStreamReader(System.in));
        int pricesCount = Integer.valueOf(scanner.readLine());
        int[] stocks = new int[pricesCount];
        for (int i = 0; i < pricesCount; i++) {
            stocks[i] = Integer.valueOf(scanner.readLine());
        }

        Stack<Integer> days = new Stack<Integer>();

        days.push(0);
        StringBuilder builder = new StringBuilder();
        builder.append(1).append("\n");

        for(int i = 1 ; i < stocks.length ; i++){
            while(!days.isEmpty() && stocks[days.peek()]<=stocks[i]){
                days.pop();
            }

            if(!days.isEmpty()) {
                builder.append(i - days.peek()).append("\n");
            }
            else {
                builder.append(i + 1).append("\n");
            }

            days.push(i);
        }

        System.out.println(builder.toString());
    }
}
