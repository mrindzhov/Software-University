import java.math.BigDecimal;
import java.util.Scanner;

public class EuroTrip {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double quantity = Double.parseDouble(scanner.nextLine());
        double kgPriceLev = 1.20;
        BigDecimal exchangeRate= new BigDecimal("4210500000000");
        BigDecimal priceInLevs= new BigDecimal(kgPriceLev*quantity);
        BigDecimal marksNeeded= exchangeRate.multiply(priceInLevs);

        System.out.printf("%.2f marks", marksNeeded);

    }
}
