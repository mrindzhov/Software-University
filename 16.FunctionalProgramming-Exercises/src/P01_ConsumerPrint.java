import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.function.Consumer;

public class P01_ConsumerPrint {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        Consumer<String[]> consumer = names -> {
            for (String name : names) {
                System.out.println(name);
            }
        };
        consumer.accept(reader.readLine().split(" "));

    }
}