import java.util.Scanner;

public class P02_MatrixOfPalindromes {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int rows = scanner.nextInt();
        int cols = scanner.nextInt();
        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".toCharArray();
        String[][]matrix=new String[rows][cols];
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                StringBuilder reminder = new StringBuilder();
                reminder.append(alphabet[row]);
                reminder.append(alphabet[row + col]);
                reminder.append(alphabet[row]);
                matrix[row][col] = reminder.toString();
            }
        }
        for (String[] strings : matrix) {
            for (String string : strings) {
                System.out.print(string+" ");
            }
            System.out.println();
        }

    }
}
