import java.util.LinkedHashSet;
import java.util.Scanner;

public class P03_VoinaNumberGame {
    private static Scanner scanner=new Scanner(System.in);
    public static void main(String[] args) {
        LinkedHashSet<Integer> firstPlayer = getNumbers();
        LinkedHashSet<Integer> secondPlayer = getNumbers();
        for (int i = 0; i < 50; i++) {
            if (firstPlayer.isEmpty() || secondPlayer.isEmpty()) {
                break;
            }
            int firstPlCard = firstPlayer.iterator().next();
            firstPlayer.remove(firstPlCard);
            int secondPlCard = secondPlayer.iterator().next();
            secondPlayer.remove(secondPlCard);
            if (firstPlCard > secondPlCard) {
                firstPlayer.add(firstPlCard);
                firstPlayer.add(secondPlCard);
            } else if (firstPlCard < secondPlCard) {
                secondPlayer.add(firstPlCard);
                secondPlayer.add(secondPlCard);
            }
        }

        if (firstPlayer.size() > secondPlayer.size()) {
            System.out.println("First player win!");
        } else if (firstPlayer.size() < secondPlayer.size()) {
            System.out.println("Second player win!");
        } else {
            System.out.println("Draw!");
        }
    }

    private static LinkedHashSet<Integer> getNumbers() {
        LinkedHashSet<Integer> currentCards = new LinkedHashSet<>();
        String[]input=scanner.nextLine().split(" ");
        for (String s : input) {
            currentCards.add(Integer.parseInt(s));
        }
        return currentCards;
    }
}
