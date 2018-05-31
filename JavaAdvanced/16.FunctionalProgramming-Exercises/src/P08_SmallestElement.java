import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.function.Function;

public class P08_SmallestElement {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<Integer> integers = new ArrayList<>();
        String line = scanner.nextLine();
        scanner = new Scanner(line);
        while (scanner.hasNextInt()) {
            integers.add(scanner.nextInt());
        }
        Function<List<Integer>, Integer> smallestNum = elements -> {
            int min=Integer.MAX_VALUE;
            int index = 0;
            for (int i = 0; i < elements.size(); i++) {
                if(elements.get(i)<=min){
                    min=elements.get(i);
                    index=i;
                }
            }
            return index;
        };
        System.out.println(smallestNum.apply(integers));
    }
}
