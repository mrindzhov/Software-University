import java.util.Scanner;

public class P03_DiagonalDifference {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        int[][]matrix=new int[n][n];
        for (int row = 0; row < n; row++) {
            String[] line = scanner.nextLine().split(" ");
            for (int col = 0; col < n; col++) {
                matrix[row][col]=Integer.parseInt(line[col]);
            }
        }
        int sumD1=0;
        int sumD2=0;
        for (int i = 0; i < n; i++) {
            sumD1 += matrix[i][i];
            sumD2 += matrix[i][n - 1 - i];
        }
        int difference=Math.abs(sumD1-sumD2);
        System.out.println(difference);
    }
}
