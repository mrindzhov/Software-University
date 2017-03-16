package P11_CatLady;

import java.util.Locale;

public class Cymric extends Cat {
    private String furLength;
    Cymric(String name,String furLength) {
        super.name=name;
        this.furLength = furLength;
    }
    @Override
    public String toString() {
        return String.format(Locale.US,"Cymric %s %s",super.name ,this.furLength);

    }

}
