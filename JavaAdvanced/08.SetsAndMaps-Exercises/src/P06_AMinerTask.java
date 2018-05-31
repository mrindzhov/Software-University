import java.util.HashMap;
import java.util.HashSet;
import java.util.Scanner;

public class P06_AMinerTask {
    public static void main(String[] args) {
        Scanner scanner =new Scanner(System.in);
        HashMap<String,Integer> resources=new HashMap<>();
        while (true) {
            String input = scanner.nextLine();
            if (input.equals("stop")) {
                break;
            }
            Integer quantity=Integer.parseInt(scanner.nextLine());
            if(!resources.containsKey(input)){
                resources.put(input,quantity);
            }else {
                resources.put(input, resources.get(input) + quantity);
            }
        }
        for (String s : resources.keySet()) {
            System.out.println(s + " -> " + resources.get(s));
        }
    }
}
