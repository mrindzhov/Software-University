import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.function.Function;

public class P04_AddVAT {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        Function<Double, String> addVat = x -> String.format("%.2f", x * 1.2).replace('.', ',');

        StringBuilder output = new StringBuilder("Prices with VAT:")
                .append(System.lineSeparator());

        Arrays.stream(reader.readLine().split(", "))
                .forEach(s -> output.append(addVat.apply(Double.valueOf(s))).append(System.lineSeparator()));

        System.out.println(output);
    }
}