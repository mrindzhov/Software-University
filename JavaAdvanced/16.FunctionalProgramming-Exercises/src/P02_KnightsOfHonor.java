import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.function.Consumer;

public class P02_KnightsOfHonor {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        StringBuilder sb = new StringBuilder();
        Consumer<String[]> consumer = names -> {
            for (String name : names) {
                sb.append(String.format("Sir %s\n", name));
            }
        };
        consumer.accept(reader.readLine().split(" "));

        System.out.println(sb);
    }
}
