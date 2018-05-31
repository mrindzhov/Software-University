package P01_Person;

class Person {
    protected String name;
    protected Integer age;

    Person(String name, Integer age) {
        setName(name);
        setAge(age);
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        if (name.length() >= 3) {
            this.name = name;
        } else {
            throw new IllegalArgumentException("Name's length should not be less than 3 symbols!");
        }
    }

    public Integer getAge() {
        return age;
    }

    public void setAge(Integer age) {
        if (age < 1) {
            throw new IllegalArgumentException("Age must be positive!");
        } else {
            this.age = age;
        }
    }

    @Override
    public String toString() {
        return String.format("Name: %s, Age: %d", this.getName(), this.getAge());
    }
}