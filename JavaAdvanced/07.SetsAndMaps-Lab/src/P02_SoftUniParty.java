import java.util.HashSet;
import java.util.Scanner;
import java.util.TreeSet;

public class P02_SoftUniParty {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        HashSet<String> vip = new HashSet<>();
        TreeSet<String> regular = new TreeSet<>();
        String numbers = "0123456789";
        while (true) {
            String guest = scanner.nextLine();
            if (guest.equals("PARTY")) {
                regular.addAll(vip);
                break;
            }else {
                String sign = Character.toString(guest.charAt(0));
                if (numbers.contains(sign)) {
                    vip.add(guest);
                } else {
                    regular.add(guest);
                }
            }
        }
        while (true) {
            String guest = scanner.nextLine();
            if (guest.equals("END")) {
                System.out.println(regular.size());
                if (!regular.isEmpty()) {
                    for (String s : regular) {
                        System.out.println(s);
                    }
                }
                break;
            } else {
                regular.remove(guest);
            }
        }
    }
}
