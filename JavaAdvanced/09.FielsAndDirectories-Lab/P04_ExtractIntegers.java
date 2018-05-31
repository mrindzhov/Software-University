import java.io.*;
import java.util.Scanner;

public class P04_ExtractIntegers {
    public static void main(String[] args) throws FileNotFoundException {
        String inputPath = "D:\\input.txt";
        String outputPath = "D:\\output.txt";
        try (Scanner scanner= new Scanner(new FileInputStream(inputPath));
             PrintWriter out = new PrintWriter(new FileOutputStream(outputPath))) {
            while (scanner.hasNext()) {
                if (scanner.hasNextInt()) {
                    out.println(scanner.nextInt());
                }
                scanner.next();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
