import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
public class P05_ConcatenatingStrings {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int n = Integer.valueOf(br.readLine());
        final long startTime = System.currentTimeMillis();
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < n; i++) {
            if (i == n - 1) {
                output.append(br.readLine());
            } else {
                output.append(br.readLine() + " ");
            }
        }
        final long endTime = System.currentTimeMillis();
        System.out.println(output);
        System.out.println("Total execution time: " + (endTime - startTime) );

    }
}
