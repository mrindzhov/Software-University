import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayDeque;
import java.util.Deque;

public class P08_ListNestedFolder {
    public static void main(String[] args) throws FileNotFoundException {
        File root = new File("D:\\Files-and-Streams");
        try {
            Deque<File> dirs = new ArrayDeque<>();
            dirs.offer(root);
            int count=0;
            while (!dirs.isEmpty()){
                File current=dirs.poll();
                System.out.println(current.getName());
                count++;
                for (File file : current.listFiles()) {
                    if (file.isDirectory()) {
                        dirs.offer(file);
                    }
                }
            }
            System.out.println(count+" folders");
        } catch (NullPointerException e) {
            e.printStackTrace();
        }
    }
}
