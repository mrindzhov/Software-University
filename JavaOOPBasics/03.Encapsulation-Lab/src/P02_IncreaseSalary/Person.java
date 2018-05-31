package P02_IncreaseSalary;


public class Person {
    private String firstName;
    private String lastName;
    private Integer age;
    private Double salary;

    Person(String firstName, String lastName, Integer age,Double salary) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary=salary;
    }

    public void increaseSalary(int bonus) {
        if (this.age > 30) {
            this.salary += this.salary * bonus / 100;
        } else {
            this.salary += this.salary * bonus / 200;
        }
    }

    @Override
    public String toString() {
        return this.firstName + " " + this.lastName + " get " + this.salary + " leva";
    }

}

