import java.util.Arrays;
import java.util.Scanner;

public class P01_ReadSortPrintArray {
    public static void main(String[] args) {
        Scanner scanner=new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        String[] lines =new String[n];
        for (int i = 0; i <n; i++) {
            lines[i]=scanner.nextLine();
        }
        Arrays.sort(lines);
        for (int i = 0; i < lines.length; i++) {
            System.out.println(lines[i]);
        }
    }
}
