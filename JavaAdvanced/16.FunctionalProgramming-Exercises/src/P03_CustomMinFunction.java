import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;
import java.util.function.Function;
import java.util.stream.Collectors;

public class P03_CustomMinFunction {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        Function<List<Integer>, Integer> getMinNumber = integers -> {
            Integer min = Integer.MAX_VALUE;
            for (Integer num : integers) {
                if (num < min)
                    min = num;
            }
            return min;
        };
        System.out.println(getMinNumber.apply(Arrays.stream(
                reader.readLine().split(" "))
                .mapToInt(Integer::valueOf).boxed()
                .collect(Collectors.toCollection(ArrayList::new))));
    }
}