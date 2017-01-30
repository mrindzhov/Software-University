import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class P12_LegendaryFarming {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        TreeMap<String, Integer> keyMaterials = new TreeMap<>();
        TreeMap<String, Integer> junk = new TreeMap<>();
        keyMaterials.put("shards", 0);
        keyMaterials.put("fragments", 0);
        keyMaterials.put("motes", 0);
        String obtained = "";
        while (obtained.equals("")) {
            String[] input = sc.nextLine().toLowerCase().split(" ");
            for (int i = 0; i < input.length; i += 2) {
                String material = input[i + 1];
                Integer quantity = Integer.valueOf(input[i]);
                if (keyMaterials.containsKey(material)) {
                    keyMaterials.put(material, keyMaterials.get(material) + quantity);
                } else {
                    if (!junk.containsKey(material)) {
                        junk.put(material, quantity);
                    } else if (junk.containsKey(material)) {
                        junk.put(material, junk.get(material) + quantity);
                    }
                }

                if (keyMaterials.get("shards") >= 250) {
                    obtained = "Shadowmourne obtained!";
                    keyMaterials.put("shards", keyMaterials.get("shards") - 250);
                    break;
                } else if (keyMaterials.get("motes") >= 250) {
                    obtained = "Dragonwrath obtained!";
                    keyMaterials.put("motes", keyMaterials.get("motes") - 250);
                    break;
                } else if (keyMaterials.get("fragments") >= 250) {
                    obtained = "Valanyr obtained!";
                    keyMaterials.put("fragments", keyMaterials.get("fragments") - 250);
                    break;
                }
            }
        }
        System.out.println(obtained);

        keyMaterials.entrySet().stream().sorted(Map.Entry.comparingByValue((v1, v2) -> v2.compareTo(v1))).forEach(pair -> {
            System.out.printf("%s: %d\n", pair.getKey(), pair.getValue());
        });
        for (String s : junk.keySet()) {
            System.out.println(s+": "+junk.get(s));
        }
    }
}
