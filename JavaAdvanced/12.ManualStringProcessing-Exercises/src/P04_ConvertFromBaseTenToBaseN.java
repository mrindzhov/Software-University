import java.math.BigInteger;
import java.util.Scanner;

public class P04_ConvertFromBaseTenToBaseN {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n= sc.nextInt();
        StringBuilder baseN = new StringBuilder();

        BigInteger base10 = sc.nextBigInteger();
        while (base10.compareTo(new BigInteger("0")) > 0) {
            BigInteger reminder = base10.divideAndRemainder(new BigInteger(n + ""))[1];
            BigInteger divide = base10.divideAndRemainder(new BigInteger(n + ""))[0];
            baseN.insert(0, reminder);
            base10 = divide;
        }
        System.out.println(baseN);
    }
}
