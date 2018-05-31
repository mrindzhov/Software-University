import java.util.Scanner;

public class GameOfNames {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int playersCount = Integer.valueOf(scanner.nextLine());

        String winnerName = "";
        long winnerScore = Long.MIN_VALUE;

        for (int i = 0; i < playersCount; i++) {
            String playerName = scanner.nextLine();

            int initialScore = Integer.valueOf(scanner.nextLine());
            long playerScore = getPlayerScore(playerName) + initialScore;

            if (playerScore > winnerScore) {
                winnerName = playerName;
                winnerScore = playerScore;
            }
        }

        System.out.printf("The winner is %s - %s points", winnerName, winnerScore);
    }

    private static long getPlayerScore(String playerName) {
        long result = 0;
        for (int i = 0; i < playerName.length(); i++) {
            char currentChar = playerName.charAt(i);
            if (currentChar % 2 == 0) {
                result += currentChar;
            }
            else {
                result -= currentChar;
            }
        }
        return result;
    }
}
