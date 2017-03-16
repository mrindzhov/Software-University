package P03_OpinionPoll;
class Person {

    String name;
    int age;

    Person() {
        this("No name", 1);
    }

    Person(String newName, int newAge) {
        this.name = newName;
        this.age = newAge;
    }

    Person(int newAge) {
        this("No name", newAge);
    }
}