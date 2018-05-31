import java.util.Scanner;

public class BaseSevenToBaseTen {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println(convertFromBaseSevenToBaseTen(scanner.nextInt()));
    }

    private static int convertFromBaseSevenToBaseTen(Integer number) {

        StringBuilder builder = new StringBuilder(number.toString());
        builder = builder.reverse();

        int baseTen = 0;
        for (int i = 0; i < builder.length() ; i++) {
            baseTen += Integer.valueOf(String.valueOf(builder.charAt(i))) * Math.pow(7, i);
        }

        return  baseTen;
    }
}
