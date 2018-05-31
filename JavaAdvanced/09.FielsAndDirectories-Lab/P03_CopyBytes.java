import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Collections;
import java.util.HashSet;

public class P03_CopyBytes {
    public static void main(String[] args) throws FileNotFoundException {
        String inputPath = "D:\\input.txt";
        String outputPath = "D:\\output.txt";
        try (FileInputStream fis = new FileInputStream(inputPath);
             FileOutputStream fos = new FileOutputStream(outputPath)) {
            int oneByte = fis.read();
            while (oneByte >= 0) {
                if (oneByte == ' ' || oneByte =='\n') {
                    fos.write(oneByte);
                } else {
                    String decimal = String.valueOf(oneByte);
                    for (Character c : decimal.toCharArray()) {
                        fos.write(c);
                    }
                }
                oneByte = fis.read();

            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
