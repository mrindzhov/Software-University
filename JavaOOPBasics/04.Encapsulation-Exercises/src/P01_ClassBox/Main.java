package P01_ClassBox;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Locale;

public class Main {

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

        Double a = Double.parseDouble(br.readLine());
        Double b = Double.parseDouble(br.readLine());
        Double c = Double.parseDouble(br.readLine());
        try {
            Box box = new Box(a, b, c);
            System.out.printf(Locale.US, "Surface Area - %.2f%nLateral Surface Area - %.2f%nVolume - %.2f%n",
                    box.getSurfaceArea(), box.getLateralSurfaceArea(), box.getVolume());

        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
}