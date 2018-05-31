import java.util.ArrayDeque;
import java.util.Scanner;
import java.util.TreeSet;

public class P03_MaximumElement {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.valueOf(scanner.nextLine());
        ArrayDeque<Integer> sequence = new ArrayDeque<>();
        TreeSet<Integer> container = new TreeSet<>();
        for (int i = 0; i < n; i++) {
            String[] inputLine = scanner.nextLine().split("\\s+");
            byte cmd;
            int val;
            if (inputLine.length >1) {
                val=Integer.parseInt(inputLine[1]);
                sequence.push(val);
                container.add(val);
            } else {
                cmd = Byte.parseByte(inputLine[0]);
                if (cmd == 2) {
                    container.remove(sequence.pop());
                } else if (cmd == 3) {
                    System.out.println(container.last());
                }
            }
        }
    }
}
/*
import java.io.BufferedReader;
        import java.io.IOException;
        import java.io.InputStreamReader;
        import java.util.*;

public class MaxElement {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        ArrayDeque<Integer> stack = new ArrayDeque<>();
        TreeSet<Integer> container = new TreeSet<>();

        int limit = Integer.valueOf(reader.readLine());

        for (int cmdInd = 0; cmdInd < limit; cmdInd++) {
            String line = reader.readLine();
            byte cmd;
            int val;

            if (line.length() > 1) {
                val = Integer.parseInt(line.substring(2));
                stack.push(val);
                container.add(val);
            } else {
                cmd = Byte.parseByte(line);
                if (cmd == 2) {
                    container.remove(stack.pop());
                } else if (cmd == 3) {
                    System.out.println(container.last());
                }
            }
        }
    }
}*/
