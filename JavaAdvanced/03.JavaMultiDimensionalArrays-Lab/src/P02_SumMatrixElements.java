import java.util.Scanner;

public class P02_SumMatrixElements {
    public static void main(String[] args) {
        Scanner scanner=new Scanner(System.in);
        String[] firstLine=scanner.nextLine().split(", ");
        int rows=Integer.parseInt(firstLine[0]);
        int cols=Integer.parseInt(firstLine[1]);
        long sum =0;
        int[][] matrix=new int[rows][cols];
        System.out.println(matrix.length);
        System.out.println(matrix[0].length);
        for (int r = 0; r < matrix.length; r++) {
            String[] line =scanner.nextLine().split(", ");
            for (int c = 0; c < matrix[r].length; c++) {
                matrix[r][c]=Integer.parseInt(line[c]);
                sum+=Integer.parseInt(line[c]);
            }
        }
        System.out.println(sum);
    }
}
