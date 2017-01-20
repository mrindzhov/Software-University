import java.util.Scanner;

public class P05_PascalTriangle {
    public static void main(String[] args) {
        Scanner scanner =new Scanner(System.in);
        int height=Integer.parseInt(scanner.nextLine());
        long[][]pascal=new long[height][];
        for (int i = 0; i < height; i++) {
            pascal[i] = new long[i + 1];
        }
        pascal[0][0]=1;
        for (int row = 1; row < pascal.length; row++) {
            pascal[row][0]=1;
            pascal[row][pascal[row].length-1]=1;
            for (int col = 1; col < pascal[row].length-1; col++) {
                pascal[row][col] = pascal[row - 1][col] + pascal[row - 1][col - 1];
            }
        }
        for (long[] longs : pascal) {
            for (long aLong : longs) {
                System.out.print(aLong+" ");
            }
            System.out.println();
        }
    }
}
