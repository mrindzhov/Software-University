import java.io.*;
import java.util.ArrayDeque;
import java.util.Deque;

public class P09_SerializeCustomObject {
    public static void main(String[] args) throws FileNotFoundException {
        Cube cube = new Cube();
        cube.color = "green";
        cube.width = 15.3d;
        cube.height = 12.4d;
        cube.depth = 3d;

        String path = "D:\\output.ser";
        try (ObjectOutputStream oos = new ObjectOutputStream(new FileOutputStream(path))) {
            oos.writeObject(cube);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
