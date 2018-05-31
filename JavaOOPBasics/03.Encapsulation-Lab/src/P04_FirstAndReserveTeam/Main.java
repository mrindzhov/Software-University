package P04_FirstAndReserveTeam;

import P03_ValidationData.Person;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedHashSet;

public class Main {
    public static void main(String[] args) throws IOException {
        LinkedHashSet<Person> persons = new LinkedHashSet<>();
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int n = Integer.valueOf(reader.readLine());
        for (int i = 0; i < n; i++) {
            String[] input = reader.readLine().split(" ");
            try {
                persons.add(new Person(input[0], input[1],
                        Integer.parseInt(input[2]), Double.parseDouble(input[3])));
            } catch (Exception e) {
                System.out.println(e.getMessage());
            }
        }
        Team team= new Team("Beroe");
        for (Person person : persons) {
            team.addPlayer(person);
        }
        System.out.println("First team have "+team.getFirstTeam().size()+" players");
        System.out.println("Reserve team have "+team.getReserveTeam().size()+" players");
    }
}