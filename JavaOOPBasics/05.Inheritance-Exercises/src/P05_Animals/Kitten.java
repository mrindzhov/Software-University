package P05_Animals;

public class Kitten extends Cat{
    private static final boolean IS_FEMALE = false;
    Kitten(String name, int age) {
        super(name, age, IS_FEMALE);
    }

    @Override
    protected String  produceSound() {
        return "Miau";
    }
}
