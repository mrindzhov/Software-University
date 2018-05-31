import java.util.*;

public class P09_UserLogs {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        TreeMap<String, LinkedHashMap<String, Integer>> users = new TreeMap<>();
        while (true) {
            String input = scanner.nextLine();
            if (input.equals("end")) {
                break;
            }
            String[] splitInput = input.split(" ");
            String[] adress = splitInput[0].split("=");
            String ip = adress[1];
            // String message = splitInput[1].split("=")[1];
            String user = splitInput[2].split("=")[1];
            if (!users.containsKey(user)) {
                users.put(user, new LinkedHashMap<>());
            }
            if (!users.get(user).containsKey(ip)) {
                users.get(user).put(ip, 1);
            } else {
                int value = users.get(user).get(ip) + 1;
                users.get(user).put(ip, value);
            }
        }
        for (Map.Entry<String, LinkedHashMap<String, Integer>> pair : users.entrySet()) {
            System.out.println(String.format("%s:",pair.getKey()));
            HashMap<String, Integer> innerMap = pair.getValue();
            StringBuilder outputBuilder = new StringBuilder();
            for (Map.Entry<String, Integer> innerPair : innerMap.entrySet()) {
                outputBuilder.append(String.format("%s => %d, ", innerPair.getKey(), innerPair.getValue()));
            }
            String output = outputBuilder.substring(0, outputBuilder.length() - 2);
            System.out.println(String.format("%s.", output));
        }
    }
}