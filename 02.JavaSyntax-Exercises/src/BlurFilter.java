import java.util.Scanner;

public class BlurFilter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int blurAmount = Integer.valueOf(scanner.nextLine());
        String[] matrixDimensions = scanner.nextLine().split("\\s+");
        int rows = Integer.valueOf(matrixDimensions[0]);
        int cols = Integer.valueOf(matrixDimensions[1]);
        long[][] matrix = getMatrix(rows, cols, scanner);

        String[] coordinates = scanner.nextLine().split("\\s+");
        int targetRow = Integer.valueOf(coordinates[0]);
        int targetCol = Integer.valueOf(coordinates[1]);
        printBlurredPhoto(matrix, targetRow, targetCol, rows, cols, blurAmount);
    }

    private static void printBlurredPhoto(long[][] matrix, int targetRow, int targetCol, int rows, int cols, int blurAmount) {
        int left = Math.max(0, targetCol - 1);
        int right = Math.min(targetCol - 1, cols);
        int top = Math.max(0, targetRow - 1);
        int bottom = Math.min(targetRow + 1, rows);
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if ((top <= r && r <= bottom) && ((left <= c) && (c <= right))) {
                    System.out.printf("%s ", matrix[r][c] + blurAmount);
                } else {
                    System.out.printf("%s ", matrix[r][c]);
                }
            }
        }
    }

    private static long[][] getMatrix(int rows, int cols, Scanner scanner) {
        long[][] matrix = new long[rows][cols];
        for (int r = 0; r < rows; r++) {
            String[] line = scanner.nextLine().split("\\s+");
            for (int c = 0; c < cols; c++) {
                matrix[r][c] = Integer.valueOf(line[c]);
            }
        }
        return matrix;
    }
}
