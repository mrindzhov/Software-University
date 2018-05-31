import java.util.*;

public class P11_LogsAggregator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        TreeMap<String, TreeSet<String>> ipAdressesMap = new TreeMap<>();
        TreeMap<String, Integer> durationsMap = new TreeMap<>();

        int n = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < n; i++) {
            String[] input = scanner.nextLine().split(" ");
            String adress = input[0];
            String username = input[1];
            Integer duration = Integer.valueOf(input[2]);

            if (!ipAdressesMap.containsKey(username)) {
                ipAdressesMap.put(username, new TreeSet<>());
                durationsMap.put(username, duration);
            } else {
                durationsMap.put(username,durationsMap.get(username)+duration);
            }
            if (!ipAdressesMap.get(username).contains(adress)) {
                ipAdressesMap.get(username).add(adress);
            }
        }
        for (String s : durationsMap.keySet()) {
            System.out.println(s+": "+durationsMap.get(s)+" "+ipAdressesMap.get(s));
        }
    }
}
/*7
192.168.0.11 peter 33
*/