package P05_Animals;

public class Cat extends Animal {
    Cat(String name, Integer age, boolean isMale) {
        super(name, age, isMale);
    }

    @Override
    protected String  produceSound() {
        return "MiauMiau";
    }
}
