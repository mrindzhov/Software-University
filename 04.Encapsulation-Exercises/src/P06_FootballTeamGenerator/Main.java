package P06_FootballTeamGenerator;
import java.util.HashMap;
import java.util.IllegalFormatException;
import java.util.Scanner;
public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();

        HashMap<String, Team> teams = new HashMap<>();
        while (!input.equals("END")) {
            try {
                String[] tokens = input.split(";");
                switch (tokens[0]) {
                    case "Team":
                        String teamName = tokens[1];
                        teams.put(teamName, new Team(teamName));
                        break;
                    case "Add":
                        addPlayer(tokens, teams);
                        break;
                    case "Remove":
                        teams.get(tokens[1]).removePlayer(tokens[2]);
                        break;
                    case "Rating":
                        showRating(tokens, teams);
                        break;
                }
            } catch (IllegalArgumentException iae) {
                System.out.println(iae.getMessage());
            }

            input = sc.nextLine();
        }
    }

    private static void addPlayer(String[] tokens, HashMap<String, Team> teams) {
        if (!teams.containsKey(tokens[1])) {
            throw new IllegalArgumentException(String.format("Team %s does not exist.", tokens[1]));
        }

        Player player = createPlayer(tokens);
        teams.get(tokens[1]).addPlayer(player);
    }

    private static void showRating(String[] tokens, HashMap<String, Team> teams) {
        if (!teams.containsKey(tokens[1])) {
            throw new IllegalArgumentException(String.format("Team %s does not exist.", tokens[1]));
        }

        System.out.println(String.format("%s - %.0f", tokens[1], teams.get(tokens[1]).getRating()));
    }

    private static Player createPlayer(String[] tokens) {
        String name = tokens[2];
        int endurance = Integer.valueOf(tokens[3]);
        int sprint = Integer.valueOf(tokens[4]);
        int dribble = Integer.valueOf(tokens[5]);
        int passing = Integer.valueOf(tokens[6]);
        int shooting = Integer.valueOf(tokens[7]);

        return new Player(name, endurance, sprint, dribble, passing, shooting);
    }
}
