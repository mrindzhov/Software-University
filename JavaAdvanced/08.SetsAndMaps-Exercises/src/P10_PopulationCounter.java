import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class P10_PopulationCounter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        LinkedHashMap<String, LinkedHashMap<String, Long>> countries = new LinkedHashMap<>();
        LinkedHashMap<String, Long> countriesTotal = new LinkedHashMap<>();

        while (!input.equals("report")) {
            String[] tokens = input.split("\\|");
            String city = tokens[0];
            String country = tokens[1];
            Long population = Long.valueOf(tokens[2]);
            if (!countries.containsKey(country)) {
                countries.put(country, new LinkedHashMap<>());
                countriesTotal.put(country, 0L);
            }
            countries.get(country).put(city, population);
            countriesTotal.put(country, countriesTotal.get(country) + population);
            input = scanner.nextLine();
        }
        countriesTotal.entrySet().stream().sorted(Map.Entry.comparingByValue((v1, v2) -> v2.compareTo(v1))).forEach(pair -> {
            System.out.println(String.format("%s (total population: %d)", pair.getKey(), pair.getValue()));
            countries.get(pair.getKey()).entrySet().stream().sorted(Map.Entry.comparingByValue((v1, v2) -> v2.compareTo(v1))).forEach(innerPair -> {
                System.out.println(String.format("=>%s: %d", innerPair.getKey(), innerPair.getValue()));
            });
        });


    }
}
