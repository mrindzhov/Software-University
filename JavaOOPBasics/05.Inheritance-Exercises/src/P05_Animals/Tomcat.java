package P05_Animals;

public class Tomcat extends Cat{
    private static final boolean IS_MALE = true;
    Tomcat(String name, Integer age) {
        super(name, age, IS_MALE);
    }



    @Override
    protected String  produceSound() {
        return "Give me one million b***h";
    }
    //male
}
