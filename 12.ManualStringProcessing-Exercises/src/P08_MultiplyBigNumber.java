import java.util.Scanner;

public class P08_MultiplyBigNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String bigNum = trimLeadingZeros(scanner.nextLine());
        Integer multiplier = Integer.parseInt(scanner.nextLine());
        if (multiplier==0){
            System.out.println(0);
            return;
        }
        StringBuilder output = new StringBuilder();

        bigNum = new StringBuffer(bigNum).reverse().toString();
        int overflow = 0;
        for (int i = 0; i < bigNum.toCharArray().length; i++) {
            int firstNum = bigNum.charAt(i) - '0';
            int newNum = firstNum * multiplier + overflow;
            overflow = newNum / 10;
            newNum %= 10;
            output.append(newNum);
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

