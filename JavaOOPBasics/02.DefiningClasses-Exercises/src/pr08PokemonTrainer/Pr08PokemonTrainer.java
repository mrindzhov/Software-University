package solutions.pr08PokemonTrainer;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.stream.Collectors;

class Pokemon {

    String name;
    String element;
    int health;

    Pokemon(String name, String element, int health) {
        this.name = name;
        this.element = element;
        this.health = health;
    }
}

class Trainer {

    String name;
    int badges;
    List<Pokemon> pokemon;

    Trainer(String name, Pokemon pokemon) {
        this.pokemon = new ArrayList<>();
        this.name = name;
        this.pokemon.add(pokemon);
    }
}

public class Pr08PokemonTrainer {

    public static void main(String[] args) throws IOException {
        BufferedReader reader =
                new BufferedReader(new InputStreamReader(System.in));
        HashSet<String> existingTrainers = new HashSet<String>();
        List<Trainer> trainers = new ArrayList<>();
        String line = reader.readLine();
        while (!line.equals("Tournament")) {
            String[] parameters = line.split("\\s+");
            String trainerName = parameters[0];
            String pokemon = parameters[1];
            String element = parameters[2];
            int health = Integer.parseInt(parameters[3]);

            Trainer existingTrainer = null;
            for (Trainer trainer : trainers) {
                if (trainer.name.equals(trainerName)) {
                    existingTrainer = trainer;
                    break;
                }
            }
            if (existingTrainer != null) {
                existingTrainer.pokemon.add(new Pokemon(pokemon, element, health));
            } else {
                trainers.add(new Trainer(trainerName, new Pokemon(pokemon, element, health)));
            }

            line = reader.readLine();
        }

        line = reader.readLine();
        while (!line.equals("End")) {
            if (line.equals("Fire")) {
                for (Trainer trainer : trainers) {
                    if (trainer.pokemon.stream().anyMatch(x -> x.element.equals("Fire"))) {
                        trainer.badges++;
                    } else {
                        for (int i = 0; i < trainer.pokemon.size(); i++) {
                            Pokemon pokemon = trainer.pokemon.get(i);
                            pokemon.health -= 10;
                            if (pokemon.health <= 0) {
                                trainer.pokemon.remove(i);
                                i--;
                            }
                        }
                    }
                }
            } else if (line.equals("Water")) {
                for (Trainer trainer : trainers) {
                    if (trainer.pokemon.stream().anyMatch(x -> x.element.equals("Water"))) {
                        trainer.badges++;
                    } else {
                        for (int i = 0; i < trainer.pokemon.size(); i++) {
                            Pokemon pokemon = trainer.pokemon.get(i);
                            pokemon.health -= 10;
                            if (pokemon.health <= 0) {
                                trainer.pokemon.remove(i);
                                i--;
                            }
                        }
                    }
                }
            } else {
                for (Trainer trainer : trainers) {
                    if (trainer.pokemon.stream().anyMatch(x -> x.element.equals("Electricity"))) {
                        trainer.badges++;
                    } else {
                        for (int i = 0; i < trainer.pokemon.size(); i++) {
                            Pokemon pokemon = trainer.pokemon.get(i);
                            pokemon.health -= 10;
                            if (pokemon.health <= 0) {
                                trainer.pokemon.remove(i);
                                i--;
                            }
                        }
                    }
                }
            }
            line = reader.readLine();
        }

        trainers = trainers.stream()
                .sorted((p1, p2) -> Integer.compare(p2.badges, p1.badges))
                .collect(Collectors.toList());

        for (Trainer trainer : trainers) {
            System.out.printf("%s %d %d%n",
                    trainer.name,
                    trainer.badges,
                    trainer.pokemon.size());
        }
    }
}
