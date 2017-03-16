package P11_CatLady;

import java.util.Locale;

public class StreetExtraordinaire extends Cat {
    private String decibelsOfMeows;

    StreetExtraordinaire(String name, String decibelsOfMeows) {
        super.name = name;
        this.decibelsOfMeows = decibelsOfMeows;
    }

    @Override
    public String toString() {

        return String.format(Locale.US, "StreetExtraordinaire %s %s", super.name, this.decibelsOfMeows);
    }
}
