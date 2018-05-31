import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Collections;
import java.util.List;

public class P07_ListFiles {
    public static void main(String[] args) throws FileNotFoundException {
        File inputPath = new File("D:\\Files and Streams Lab");

        try {
            if (inputPath.exists()){
                if(inputPath.isDirectory()){
                    File[]files=inputPath.listFiles();
                    for (File file : files) {
                        if (!file.isDirectory()) {
                            System.out.println(file.getName()+": "+file.length());
                        }
                    }
                }
            }
        } catch (NullPointerException e) {
            e.printStackTrace();
        }
    }
}
