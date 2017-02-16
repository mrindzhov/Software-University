import java.util.*;
import java.util.stream.Collectors;

public class P06_ReverseAndExclude {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<Integer> nums = Arrays.stream(scanner.nextLine().split(" ")).map(Integer::parseInt).collect(Collectors.toList());
        Integer divisor = Integer.valueOf(scanner.nextLine());
        nums=filter(nums, divisor);
        for (Integer num : nums) {
            System.out.printf("%s ",num);
        }
    }
    private static List<Integer> filter(List<Integer>integers,Integer divisor) {
        List<Integer>copy=new ArrayList<>(integers);
        for (Integer integer : integers) {
            if (integer % divisor == 0) {
                copy.remove(integer);
            }
        }
        Collections.reverse(copy);
        return copy;
    }
}