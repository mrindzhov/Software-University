package P11_CatLady;

import java.util.LinkedHashMap;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc=new Scanner(System.in);
        LinkedHashMap<String,Cat>cats=new LinkedHashMap<>();
        while (true) {
            String input = sc.nextLine();
            if (input.equals("End")) {
                break;
            }
            String[] inputArgs = input.split(" ");
            String breed=inputArgs[0];
            String name=inputArgs[1];
            String specification= inputArgs[2];
            Cat cat=null;
            switch (breed) {
                case "Siamese":
                    cat=new Siamese(name,specification);
                    break;
                case "Cymric":
                    cat=new Cymric(name,specification);
                    break;
                case "StreetExtraordinaire":
                    cat=new StreetExtraordinaire(name,specification);
                    break;
            }
            cats.put(name,cat);
        }
        System.out.println(cats.get(sc.nextLine().trim()));

    }
}
