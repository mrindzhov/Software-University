package P04_FirstAndReserveTeam;

import P03_ValidationData.Person;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Team {
    private String name;
    private ArrayList<Person> firstTeam;
    private ArrayList<Person> reserveTeam;
    Team(String name) {
        this.name = name;
        this.firstTeam = new ArrayList<>();
        this.reserveTeam = new ArrayList<>();
    }

    public void addPlayer(Person person) {
        if (person.getAge() >= 40) {
            reserveTeam.add(person);
        } else {
            firstTeam.add(person);
        }
    }

    public List<Person> getFirstTeam() {
        return Collections.unmodifiableList(this.firstTeam);
    }

    public List<Person> getReserveTeam() {
        return Collections.unmodifiableList(this.reserveTeam);
    }
}