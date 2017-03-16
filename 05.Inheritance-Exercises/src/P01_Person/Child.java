package P01_Person;

class Child extends Person {

    Child(String name, Integer age) {
        super(name, age);
    }

    @Override
    public void setAge(Integer age) {
        if (age <= 15) {
            super.setAge(age);
        } else {
            throw new IllegalArgumentException("Child's age must be lesser than 15!");
        }
    }
}
