package P05_Animals;

class Frog extends Animal{
    Frog(String name, Integer age, boolean gender) {
        super(name, age, gender);
    }
    @Override
    protected String  produceSound() {
        return "Frogggg";
    }
}
