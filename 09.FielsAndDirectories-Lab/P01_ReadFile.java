import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;

public class P01_ReadFile {
    public static void main(String[] args) throws FileNotFoundException {
        String path = "C:\\inputFile.txt";

        try(FileInputStream fis = new FileInputStream(path)) {
            int oneByte=fis.read();
            while(oneByte>=0){
                System.out.print(Integer.toBinaryString(oneByte)+" ");
                oneByte=fis.read();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
