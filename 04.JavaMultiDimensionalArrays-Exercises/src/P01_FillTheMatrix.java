import java.util.Scanner;

public class P01_FillTheMatrix {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(", ");
        int n = Integer.parseInt(input[0]);
        String pattern = input[1];
        int[][] matrix;
        if (pattern.equals("A")) {
            matrix = fillMatrixPatternA(n);
        } else if (pattern.equals("B")) {
            matrix = fillMatrixPatternB(n);
        } else {
            matrix = new int[n][n];
        }
        for (int row = 0; row < n; row++) {
            for (int col = 0; col < n; col++) {
                System.out.print(matrix[row][col]+" ");
            }
            System.out.println();
        }
    }

    private static int[][] fillMatrixPatternB(int n) {
        int[][] matrix = new int[n][n];
        boolean direction = true;
        int counter = 1;

        for (int col = 0; col < n; col++) {
            if (direction) {
                for (int row = 0; row < n; row++) {
                    matrix[row][col] = counter;
                    counter++;
                }
                direction = !direction;
            } else {
                for (int row = n - 1; row >= 0; row--) {
                    matrix[row][col] = counter;
                    counter++;
                }
                direction = !direction;
            }
        }
        return matrix;
    }

    private static int[][] fillMatrixPatternA(int n) {
        int[][] matrix = new int[n][n];
        int counter = 1;

        for (int col = 0; col < n; col++) {
            for (int row = 0; row < n; row++) {
                matrix[row][col] = counter;
                counter++;
            }
        }
        return matrix;
    }
}
