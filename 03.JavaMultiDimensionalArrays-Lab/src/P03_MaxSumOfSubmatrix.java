import java.util.Scanner;

public class P03_MaxSumOfSubmatrix {
    public static void main(String[] args) {
        Scanner scanner=new Scanner(System.in);
        String[] firstLine=scanner.nextLine().split(", ");
        int rows=Integer.parseInt(firstLine[0]);
        int cols=Integer.parseInt(firstLine[1]);
        long bestSum = Integer.MIN_VALUE;
        int[][] matrix=new int[rows][cols];
        int targetRow=0;
        int targetCol=0;
        for (int r = 0; r < matrix.length; r++) {
            String[] line =scanner.nextLine().split(", ");
            for (int c = 0; c < matrix[r].length; c++) {
                matrix[r][c]=Integer.parseInt(line[c]);
            }
        }
        for (int row = 0; row < matrix.length-1; row++) {
            for (int col = 0; col < matrix[row].length-1; col++) {
                int sum = matrix[row][col]
                        + matrix[row + 1][col]
                        + matrix[row][col + 1]
                        + matrix[row + 1][col + 1];
                if(sum>bestSum) {
                    bestSum = sum;
                    targetRow = row;
                    targetCol = col;
                }
            }
        }
        System.out.println(matrix[targetRow][targetCol]+" "
                +matrix[targetRow][targetCol+1]);

        System.out.println(matrix[targetRow+1][targetCol]+" "
                +matrix[targetRow+1][targetCol+1]);

        System.out.println(matrix[targetRow][targetCol]
                +matrix[targetRow+1][targetCol]+matrix[targetRow][targetCol+1]
                +matrix[targetRow+1][targetCol+1]);
    }
}
