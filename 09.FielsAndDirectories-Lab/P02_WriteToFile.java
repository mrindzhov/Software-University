import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Collections;
import java.util.HashSet;

public class P02_WriteToFile {
    public static void main(String[] args) throws FileNotFoundException {
        String inputPath = "inputFile.txt";
        String outputPath="outputFile.txt";
        HashSet<Character> elementsToSkip=new HashSet<>();
        Collections.addAll(elementsToSkip,',','.','!','?');
        try(FileInputStream fis = new FileInputStream(inputPath);
            FileOutputStream fos = new FileOutputStream(outputPath)) {
            int oneByte=fis.read();
            while(oneByte>=0) {
                if (!elementsToSkip.contains((char) oneByte)) {
                    fos.write(oneByte);
                }
                oneByte = fis.read();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
