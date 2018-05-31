import java.util.Scanner;

public class P07_SumBigNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String longerBigN = trimLeadingZeros(scanner.nextLine());
        String shorterBigN = trimLeadingZeros(scanner.nextLine());
        if (longerBigN.length() < shorterBigN.length()) {
            String temp = shorterBigN;
            shorterBigN = longerBigN;
            longerBigN = temp;
        }
        StringBuilder output = new StringBuilder();
        longerBigN = new StringBuffer(longerBigN).reverse().toString();
        shorterBigN = new StringBuffer(shorterBigN).reverse().toString();
        int overflow = 0;
        for (int i = 0; i < shorterBigN.toCharArray().length; i++) {
            int firstNum = longerBigN.charAt(i)-'0';
            int secondNum = shorterBigN.charAt(i)-'0';
            int newNum = firstNum + secondNum + overflow;
            overflow = newNum / 10;
            newNum %= 10;
            output.append(newNum);
        }
        for (int i = shorterBigN.length(); i < longerBigN.length(); i++) {
            int longDigit = longerBigN.charAt(i)-'0';
            int digitSum = longDigit + overflow;
            overflow = digitSum / 10;
            digitSum %= 10;
            output.append(digitSum);
        }
        if (overflow != 0) {
            output.append(overflow);
        }
        System.out.println(output.reverse());
    }

    private static String trimLeadingZeros(String input) {
        int i = 0;
        while (input.charAt(i) == '0') {
            i++;
        }

        return input.substring(i);
    }
}