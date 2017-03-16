package P11_CatLady;

import java.util.Locale;

public class Siamese extends  Cat {
    private String earSize;

    Siamese(String name,String earSize) {
        super.name=name;
        this.earSize = earSize;
    }

    @Override
    public String toString() {
        return String.format(Locale.US,"Siamese %s %s",super.name ,this.earSize);
    }

}
