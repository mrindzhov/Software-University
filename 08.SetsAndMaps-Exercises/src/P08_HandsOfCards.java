import java.util.HashSet;
import java.util.LinkedHashMap;
import java.util.Scanner;

public class P08_HandsOfCards {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        LinkedHashMap<String,String> playerCards = new LinkedHashMap<>();
        String numbers="2345678910";
        LinkedHashMap<String,Integer> jtoAValues= new LinkedHashMap<>();
        jtoAValues.put("J",11);
        jtoAValues.put("Q",12);
        jtoAValues.put("K",13);
        jtoAValues.put("A",14);
        LinkedHashMap<String,Integer> cardTypes= new LinkedHashMap<>();
        cardTypes.put("S",4);
        cardTypes.put("H",3);
        cardTypes.put("D",2);
        cardTypes.put("C",1);
        while (true) {
            String player = scanner.nextLine();
            if (player.equals("JOKER")) {
                break;
            }
            String name = player.split(": ")[0];
            String cards = player.split(": ")[1];
            if (!playerCards.containsKey(name)) {
                playerCards.put(name, cards);
            } else {
                playerCards.put(name, playerCards.get(name) + ", " + cards);
            }
        }
        int currResult=0;
        for (String s : playerCards.keySet()) {
            HashSet<Integer> points=new HashSet<>();

            for (String card : playerCards.get(s).split(", ")) {
                String power = card.substring(0, card.length() - 1);
                String type = card.substring(card.length() - 1);
                if (numbers.contains(power)) {
                    int cardResult = Integer.parseInt(power) * cardTypes.get(type);
                    if (!points.contains(cardResult)) {
                        currResult += cardResult;
                        points.add(cardResult);
                    }
                } else {
                    int cardResult = jtoAValues.get(power) * cardTypes.get(type);
                    if (!points.contains(cardResult)) {
                        currResult += cardResult;
                        points.add(cardResult);
                    }
                }
            }
            System.out.println(s+": "+ currResult);
            currResult=0;
        }

    }
}
