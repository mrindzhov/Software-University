import java.util.Scanner;

public class P05_MaximalSum {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        int rows = Integer.parseInt(input[0]);
        int cols = Integer.parseInt(input[1]);
        int[][] matrix=fillMatrix(rows,cols,scanner);
        int targetRow = 0;
        int targetCol = 0;
        long bestSum = Integer.MIN_VALUE;
        for (int row = 0; row < matrix.length - 2; row++) {
            for (int col = 0; col < matrix[row].length - 2; col++) {
                long sum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                        matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                        matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];
                if (sum > bestSum) {
                    bestSum = sum;
                    targetRow = row;
                    targetCol = col;
                }
            }
        }
        System.out.println("Sum = " + bestSum);
        for (int row = targetRow; row <= targetRow + 2; row++) {
            for (int col = targetCol; col <= targetCol + 2; col++) {
                System.out.print(matrix[row][col] + " ");
            }
            System.out.println();
        }
    }

    private static int[][] fillMatrix(int rows, int cols,Scanner scanner) {
        int[][]matrix=new int[rows][cols];
        for (int row = 0; row < matrix.length; row++) {
            String[] line = scanner.nextLine().split(" ");
            for (int col = 0; col < matrix[row].length; col++) {
                matrix[row][col] = Integer.parseInt(line[col]);
            }
        }
        return matrix;
    }
}