import java.math.BigInteger;
import java.util.Scanner;

public class P05_ConvertFromBaseNtoBase10 {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        BigInteger base = sc.nextBigInteger();
        String number = sc.nextBigInteger().toString();
        BigInteger nPower=BigInteger.ONE;
        StringBuilder numberRev = new StringBuilder(number).reverse();
        BigInteger res = new BigInteger("0");
        for (int i = 0; i < number.toCharArray().length ; i++) {

            Integer integer = (int) numberRev.charAt(i) - '0';
            BigInteger num = new BigInteger((integer+"")).multiply(nPower);
            res = res.add(num);
            nPower = nPower.multiply(base);
        }
        System.out.println(res);
    }
}