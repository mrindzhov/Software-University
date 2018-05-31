package P02_AnimalFarm;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        String name = br.readLine();
        Integer age = Integer.parseInt(br.readLine());
        try {
            Chicken chicken = new Chicken(name, age);
            System.out.println(chicken.toString());

        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
}