import java.util.Scanner;

public class ReadInput {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String firstWord = scanner.next();
        String secondWord = scanner.next();
        int numInt = scanner.nextInt();
        double numDouble1 = scanner.nextDouble();
        double numDouble2 = scanner.nextDouble();
        scanner.nextLine();
        String thirdWord = scanner.nextLine();
        int sum =(int) (numInt + numDouble1 + numDouble2);
        System.out.println(firstWord + " " + secondWord + " " + thirdWord + " " + sum);

    }
}
