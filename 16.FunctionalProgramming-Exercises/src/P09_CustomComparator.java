import java.util.*;

public class P09_CustomComparator {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Integer[] numbers = readInput();
        Arrays.sort(numbers, customIntegerComparator);
        printResult(numbers);


    }
    private static Comparator<Integer> customIntegerComparator = new Comparator<Integer>() {
        @Override
        public int compare(Integer i1, Integer i2) {
            if ((i1 % 2 == 0) && (i2 % 2 != 0)) {
                return -1;
            } else if ((i1 % 2 != 0) && (i2 % 2 == 0)) {
                return 1;
            } else {
                if (i1 < i2) {
                    return -1;
                } else if (i1 > i2) {
                    return 1;
                } else {
                    return 0;
                }
            }
        }
    };
    private static void printResult(Integer[] result) {
        for (Integer currentString : result) {
            System.out.printf("%s ", currentString);
        }
    }

    private static Integer[] readInput() {
        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();
        scan = new Scanner(line);

        List<Integer> numbers = new ArrayList<>();

        while (scan.hasNextInt()) {
            Integer n = scan.nextInt();
            numbers.add(n);
        }

        Integer[] result = new Integer[numbers.size()];
        return numbers.toArray(result);
    }
}