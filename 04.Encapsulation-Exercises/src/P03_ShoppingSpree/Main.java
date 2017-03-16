package P03_ShoppingSpree;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedHashMap;
import java.util.stream.Collectors;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

        LinkedHashMap<String, Product> products = new LinkedHashMap<>();
        LinkedHashMap<String, Person> buyers = new LinkedHashMap<>();
        try {
        FillPeople(br, buyers);
        FillProducts(br, products);

        String input = br.readLine();

        while (!input.equals("END")) {
            String[] tokens = input.split("\\s+");
            String personName = tokens[0];
            String productName = tokens[1];

            try {
                Person person = buyers.get(personName);
                Product product = products.get(productName);
                person.buyProduct(product);
                System.out.println(String.format("%s bought %s", personName, productName));
            } catch (Exception ise) {
                System.out.println(ise.getMessage());
            }

            input = br.readLine();
        }


            for (String personName : buyers.keySet()) {
                String items = String.join(", ", buyers.get(personName).getBagOfProducts().stream()
                        .map(Product::toString)
                        .collect(Collectors.toList()));
                String result = items.length() == 0 ? "Nothing bought" : items;
                System.out.printf("%s - %s%n",
                        personName, result);
            }
        } catch (Exception iae)
        {
            System.out.println(iae.getMessage());
        }

    }

    private static void FillProducts(BufferedReader br, LinkedHashMap<String, Product> products) throws IOException {
        String[] productsInput = br.readLine().split(";");
        for (String product : productsInput) {
            String[] productTokens = product.split("=");
            String name = productTokens[0];
            Double price = Double.parseDouble(productTokens[1]);
                products.put(name, new Product(name, price));

        }
    }

    private static void FillPeople(BufferedReader br, LinkedHashMap<String, Person> buyers) throws IOException {
        String[] people = br.readLine().split(";");
        for (String person : people) {
            String[] personTokens = person.split("=");
            String name = personTokens[0];
            Double money = Double.parseDouble(personTokens[1]);
            buyers.put(name, new Person(name, money));

        }
    }
}