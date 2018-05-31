package P02_AnimalFarm;

class Chicken {
    private String name;
    private Integer age;
    private String eggPerDay;

    Chicken(String name, Integer age) {
        this.setName(name);
        this.setAge(age);
        this.CalculateProductPerDay();
    }

    private Integer getAge() {
        return age;
    }

    private void setAge(Integer age) {
        if (age > 0 && age < 15) {
            this.age = age;
        } else {
            throw new IllegalStateException("Age should be between 0 and 15.");
        }
    }

    private String getName() {
        return name;
    }

    private void setName(String name) {
        if (name.isEmpty() || name.contains(" ")) {
            throw new IllegalStateException("Name cannot be empty.");
        } else {
            this.name = name;
        }
    }

    private String getEggPerDay() {
        return eggPerDay;
    }

    private void CalculateProductPerDay() {
        if (this.getAge() < 6) {
            this.eggPerDay = "2";
        } else if (this.getAge() < 12) {
            this.eggPerDay = "1";
        } else {
            this.eggPerDay = "0.75";
        }
    }

    @Override
    public String toString() {
        return "Chicken " + getName() + " (age " + getAge() + ") can produce " + getEggPerDay() + " eggs per day.";
    }
}