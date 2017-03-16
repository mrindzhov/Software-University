package P05_Animals;

abstract class Animal {
    private String name;
    private Integer age;
    private boolean isMale;

    Animal(String name, Integer age, boolean isMale) {
        setName(name);
        setAge(age);
        setGender(isMale);
    }

    private String getName() {
        return name;
    }

    private void setName(String name) {
        if (name.isEmpty()) {
            throw new IllegalArgumentException("Invalid input!");
        }
        this.name = name;
    }

    private Integer getAge() {
        return age;
    }

    private void setAge(Integer age) {
        if (age > 0) {
            this.age = age;
        } else {
            throw new IllegalArgumentException("Invalid input!");
        }
    }

    public boolean isMale() {
        return isMale;
    }

    private void setGender(boolean gender) {
        this.isMale = gender;
    }

    protected String produceSound() {
        return "Not implemented!";
    }

    @Override
    public String toString() {
        return String.format("%s%n%s %d %s%n", getClass().getSimpleName(), getName(), getAge(),
                isMale() ? "Male" : "Female");
    }
}