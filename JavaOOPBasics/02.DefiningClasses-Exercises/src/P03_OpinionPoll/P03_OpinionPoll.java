package P03_OpinionPoll;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class P03_OpinionPoll {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int lines = Integer.parseInt(reader.readLine());
        List<Person> people = new ArrayList<>();
        for (int i = 0; i < lines; i++) {
            String[] parameters = reader.readLine().split(" ");
            String name = parameters[0];
            int age = Integer.parseInt(parameters[1]);
            people.add(new Person(name, age));
        }

        people = people.stream()
                .filter(x -> x.age > 30)
                .sorted((p1, p2) -> p1.name.compareTo(p2.name))
                .collect(Collectors.toList());
        for (Person person : people) {
            System.out.printf("%s - %d%n", person.name, person.age);
        }
    }
}
