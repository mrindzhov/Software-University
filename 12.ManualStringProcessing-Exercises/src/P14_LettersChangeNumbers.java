import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P14_LettersChangeNumbers {
    public static void main(String[] args) {
        Scanner scanner=new Scanner(System.in);
        String[] input= scanner.nextLine().split("\\s+");

        double result=0;
        for (String str : input) {
            Character firstLetter = str.charAt(0);
            Character secondLetter = str.charAt(str.length() - 1);
            double number = Double.valueOf(str.substring(1, str.length()-1));
            number = getNumber(firstLetter, secondLetter, number);
            result += number;
        }
        System.out.printf("%.2f",result);
    }

    private static double getNumber(Character firstLetter, Character secondLetter, double number) {
        String alphabetUpper="0ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        String alphabetLower="0abcdefghijklmnopqrstuvwxyz";

        if (Character.isLowerCase(firstLetter)) {
            number *= (double) alphabetLower.indexOf(firstLetter);
        } else {
            number /= (double) alphabetUpper.indexOf(firstLetter);
        }
        if (Character.isLowerCase(secondLetter)) {
            number += (double) alphabetLower.indexOf(secondLetter);
        } else {
            number -= (double) alphabetUpper.indexOf(secondLetter);
        }
        return number;
    }
}
