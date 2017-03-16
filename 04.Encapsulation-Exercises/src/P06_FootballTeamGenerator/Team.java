package P06_FootballTeamGenerator;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

public class Team {
    private String name;
    private List<Player> players;

    public Team(String name) {
        this.name = name;
        this.players = new ArrayList<>();
    }

    public String getName() {
        return this.name;
    }

    public void addPlayer(Player player) {
        this.players.add(player);
    }

    public Player getPlayer(String name) {
        Optional<Player> player = this.players.stream().filter(p -> p.getName().equals(name)).findFirst();

        if (player.isPresent()) {
            return player.get();
        } else {
            return null;
        }
    }

    public Player getPlayer(int number) {
        return this.players.stream().filter(p -> p.getNumber() == number).findFirst().get();
    }

    public void removePlayer(String playerName) {
        Player player = this.getPlayer(playerName);
        if (player == null) {
            throw new IllegalArgumentException(String.format("Player %s is not in %s team.", playerName, this.name));
        }

        this.players.remove(player);
    }

    public double getRating() {
        Optional<Double> rating = this.players.stream().map(p -> p.getAverageStats()).reduce((x, y) -> x + y);
        if (!rating.isPresent()) {
            return 0;
        }

        return Math.round(rating.get() / this.players.size());
    }
}