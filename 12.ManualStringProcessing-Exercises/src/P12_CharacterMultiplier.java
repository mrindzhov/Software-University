import java.math.BigInteger;
import java.util.Scanner;

public class P12_CharacterMultiplier {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String longerStr = scanner.next();
        String shorterStr = scanner.next();
        if (longerStr.length() < shorterStr.length()) {
            String temp = shorterStr;
            shorterStr = longerStr;
            longerStr = temp;
        }
        System.out.println(GetSumOfCharacters(longerStr, shorterStr));
    }

    private static BigInteger GetSumOfCharacters(String longerStr, String shorterStr) {
        BigInteger output = BigInteger.ZERO;
        for (int i = 0; i < shorterStr.toCharArray().length; i++) {
            int firstNum = longerStr.charAt(i);
            int secondNum = shorterStr.charAt(i);
            int newNum = firstNum * secondNum;
            output = output.add(BigInteger.valueOf(newNum));
        }
        if (longerStr.length() > shorterStr.length()) {
            for (int i = shorterStr.length(); i < longerStr.length(); i++) {
                int longDigit = longerStr.charAt(i);
                output = output.add(BigInteger.valueOf(longDigit));
            }
        }
        return output;
    }
}