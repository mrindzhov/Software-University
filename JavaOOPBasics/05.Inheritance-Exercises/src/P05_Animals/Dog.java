package P05_Animals;

class Dog extends Animal{
    Dog(String name, Integer age, boolean gender) {
        super(name, age, gender);
    }

    @Override
    protected String  produceSound() {
        return "BauBau";
    }
}
