package P01_SortPeopleByNameAndAge;


public class Person {
    private String firstName;
    private String lastName;
    private Integer age;

    Person(String firstName, String lastName, Integer age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public String getFirstName() {
        return this.firstName;
    }

    public Integer getAge() {
        return this.age;
    }

    @Override
    public String toString() {
        return this.firstName + " " + this.lastName + " is a " + this.age + " years old.";
    }
}