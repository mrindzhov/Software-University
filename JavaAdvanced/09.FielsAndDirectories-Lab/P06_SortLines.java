import java.io.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Collections;
import java.util.List;

public class P06_SortLines {
    public static void main(String[] args) throws FileNotFoundException {
        Path inputPath = Paths.get("D:\\input.txt");
        Path outputPath = Paths.get("D:\\output.txt");
        try {
            List<String> lines= Files.readAllLines(inputPath);
            Collections.sort(lines);
            Files.write(outputPath,lines);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
