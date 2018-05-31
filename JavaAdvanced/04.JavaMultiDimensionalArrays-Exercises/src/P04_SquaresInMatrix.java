import java.util.Scanner;

public class P04_SquaresInMatrix {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        int rows = Integer.parseInt(input[0]);
        int cols = Integer.parseInt(input[1]);
        String [][] matrix = new String[rows][cols];
        for (int row = 0; row < matrix.length; row++) {
            String[] line = scanner.nextLine().split(" ");
            for (int col = 0; col < matrix[row].length; col++) {
                matrix[row][col] = line[col];
            }
        }
        int counter=0;
        for (int row = 0; row < matrix.length-1; row++) {
            for (int col = 0; col < matrix[row].length-1; col++) {
                if ((matrix[row][col].equals(matrix[row + 1][col]))
                        && (matrix[row][col].equals(matrix[row][col + 1]))
                        && (matrix[row][col].equals(matrix[row+1][col + 1]))){
                    counter++;
                }
            }
        }
        System.out.println(counter);
    }
}
