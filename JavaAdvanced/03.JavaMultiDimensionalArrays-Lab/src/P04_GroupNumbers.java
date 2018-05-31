import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class P04_GroupNumbers {
    public static void main(String[] args) {
        Scanner scanner=new Scanner(System.in);
        String[]input=scanner.nextLine().split(", ");
        ArrayList<ArrayList<String>> matrix=new ArrayList<>();
        matrix.add(0,new ArrayList<>());
        matrix.add(1,new ArrayList<>());
        matrix.add(2,new ArrayList<>());
        for (String s : input) {
            int curNum=Integer.parseInt(s);
            matrix.get(Math.abs(curNum)%3).add(s);
        }
        for (ArrayList<String> strings : matrix) {
            for (String string : strings) {
                System.out.print(string+" ");
            }
            System.out.println();
        }
    }
}
//1, 4, 113, 55, 3, 1, 2, 66, 557, 124, 2