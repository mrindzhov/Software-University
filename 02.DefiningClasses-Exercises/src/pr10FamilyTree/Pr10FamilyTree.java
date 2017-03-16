package solutions.pr10FamilyTree;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

class Person {

    String firstName;
    String lastName;
    String birthdate;
    List<Person> parents;
    List<Person> children;

    public Person(String firstName, String lastName, String birthdate) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthdate = birthdate;
        this.parents = new ArrayList<>();
        this.children = new ArrayList<>();
    }

    public Person(String firstName, String lastName) {
        this(firstName, lastName, null); }

    public Person(String birthDate) {
        this(null, null, birthDate);
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder();
        output.append(String.format("%s %s %s%n", this.firstName, this.lastName, this.birthdate));
        output.append(String.format("Parents:%n"));
        for (Person parent : parents) {
            output.append(String.format("%s %s %s%n", parent.firstName, parent.lastName, parent.birthdate));
        }
        output.append(String.format("Children:%n"));
        for (Person child : children) {
            output.append(String.format("%s %s %s%n", child.firstName, child.lastName, child.birthdate));
        }
        return output.toString();
    }
}

public class Pr10FamilyTree { // needs work

    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        HashMap<String, Person> peopleWithNames = new HashMap<>();
        HashMap<String, Person> peopleWithBirthday = new HashMap<>();

        List<Person> familyTree = new ArrayList<>();
        String input = reader.readLine().trim();
        boolean nameGiven = false;
        if (input.contains(" ")) {
            nameGiven = true;
        }

        while (true) {
            String line = reader.readLine();
            if (line.equals("End")) {
                break;
            }

            String[] parameters = line.split(" - ");
            if (parameters.length == 2) {
                Person parent = null;
                Person child = null;
                if (parameters[0].contains(" ")) {
                    if (peopleWithNames.containsKey(parameters[0])) {
                        parent = peopleWithNames.get(parameters[0]);
                    } else {
                        parent = null;
                    }
                } else {
                    if (peopleWithBirthday.containsKey(parameters[0])) {
                        parent = peopleWithBirthday.get(parameters[0]);
                    } else {
                        parent = null;
                    }
                }
                if (parameters[1].contains(" ")) {
                    if (peopleWithNames.containsKey(parameters[1])) {
                        child = peopleWithNames.get(parameters[1]);
                    } else {
                        child = null;
                    }
                } else {
                    if (peopleWithBirthday.containsKey(parameters[1])) {
                        child = peopleWithBirthday.get(parameters[1]);
                    } else {
                        child = null;
                    }
                }

                if (parent == null) {
                    if (parameters[0].contains(" ")) {
                        String[] parentName = parameters[0].split("\\s+");
                        parent = new Person(parentName[0], parentName[1]);
                        peopleWithNames.put(parameters[0], parent);
                    } else {
                        parent = new Person(parameters[0]);
                        peopleWithBirthday.put(parameters[0], parent);
                    }
                    familyTree.add(parent);
                }
                if (child == null) {
                    if (parameters[1].contains(" ")) {
                        String[] childNames = parameters[1].split("\\s+");
                        child = new Person(childNames[0], childNames[1]);
                        peopleWithNames.put(parameters[1], child);
                    } else {
                        child = new Person(parameters[1]);
                        peopleWithBirthday.put(parameters[1], child);
                    }
                    familyTree.add(child);
                }
                parent.children.add(child);
                child.parents.add(parent);

            } else if (parameters.length == 1) {

                String[] subParams = parameters[0].split("\\s+");

                Person personWithName = null;
                String fullName = String.format("%s %s", subParams[0], subParams[1]);
                if (peopleWithNames.containsKey(fullName)) {
                    personWithName = peopleWithNames.get(fullName);
                }

                Person personWithBirthdate = null;
                if (peopleWithBirthday.containsKey(subParams[2])) {
                    personWithBirthdate = peopleWithBirthday.get(subParams[2]);
                }

                //both people exist, so we should merge them into one
                if (personWithName != null && personWithBirthdate != null) {
                    int indexPersonName = familyTree.indexOf(personWithName);
                    int indexPersonBirthdate = familyTree.indexOf(personWithBirthdate);

                    //we need to keep track of which person came first in the input, we do this by checking their
                    // index in the family tree, the one who came first will have a lower index
                    if (indexPersonName < indexPersonBirthdate) {
                        //pass all known information about the second person to the first
                        personWithName.birthdate = personWithBirthdate.birthdate;
                        for (Person parent : personWithBirthdate.parents) {
                            parent.children.remove(personWithBirthdate);
                            parent.children.add(personWithName);
                            personWithName.parents.add(parent);
                        }
                        for (Person child : personWithBirthdate.children) {
                            child.parents.remove(personWithBirthdate);
                            child.parents.add(personWithName);
                            personWithName.children.add(child);
                        }
                    } else {
                        personWithBirthdate.firstName = personWithName.firstName;
                        personWithBirthdate.lastName = personWithName.lastName;
                        for (Person parent : personWithName.parents) {
                            parent.children.remove(personWithName);
                            parent.children.add(personWithBirthdate);
                            personWithBirthdate.parents.add(parent);
                        }
                        for (Person child : personWithName.children) {
                            child.parents.remove(personWithName);
                            child.parents.add(personWithBirthdate);
                            personWithBirthdate.children.add(child);
                        }
                    }
                } else if (personWithBirthdate != null) {
                    //only one one person exist so we just add information to him
                    personWithBirthdate.firstName = subParams[0];
                    personWithBirthdate.lastName = subParams[1];
                    peopleWithNames.put(fullName, personWithBirthdate);
                } else if (personWithName != null) {
                    //only one one person exist so we just add information to him
                    personWithName.birthdate = subParams[2];
                    peopleWithBirthday.put(subParams[2], personWithName);
                } else {
                    //if the person didn't exist at all add a new person
                    Person newPerson = new Person(subParams[0], subParams[1], subParams[2]);
                    peopleWithBirthday.put(subParams[2], newPerson);
                    peopleWithNames.put(fullName, newPerson);
                    familyTree.add(newPerson);
                }
            }
        }

        if (nameGiven) {
            String[] name = input.split("\\s+");
            final String fName = name[0];
            final String lName = name[1];
            Person searched = familyTree.stream()
                    .filter(x -> x.firstName.equals(fName) && x.lastName.equals(lName))
                    .findFirst().get();
            System.out.print(searched);
        } else {
            final String bDay = input;
            Person searched = familyTree.stream()
                    .filter(x -> x.birthdate.equals(bDay))
                    .findFirst().get();
            System.out.print(searched);
        }
    }
}