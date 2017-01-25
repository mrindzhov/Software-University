import java.util.Scanner;

public class P09_RecursiveFibonacci {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.valueOf(scanner.nextLine());
        long[] array=new long[n+1];
        array[0]=1;
        array[1]=1;
        for (int i = 2; i < array.length; i++) {
            array[i] = -1;
        }
        System.out.println(fibonacci(n,array));
    }

    private static long fibonacci(int n,long[]array) {
        if(array[n]!=-1) {
            return array[n];
        }
        array[n] = fibonacci(n - 1, array) + fibonacci(n - 2, array);
        return array[n];
    }
}
