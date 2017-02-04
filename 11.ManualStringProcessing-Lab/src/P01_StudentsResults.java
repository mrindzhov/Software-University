import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.TreeMap;

public class P01_StudentsResults {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int n = Integer.valueOf(br.readLine());
        TreeMap<String, ArrayList<Double>> students = new TreeMap<>();
        for (int i = 0; i < n; i++) {
            String[] arg = br.readLine().split(" - ");
            String name = arg[0];
            String[] secondPart = arg[1].split(", ");
            ArrayList<Double> grades = new ArrayList<>();
            for (String s : secondPart) {
                grades.add(Double.valueOf(s));
            }
            students.put(name, grades);
        }
        if(!students.isEmpty()){
            System.out.println(String.format("%1$-10s|%2$7s|%3$7s|%4$7s|%5$7s|", "Name", "JAdv", "JavaOOP", "AdvOOP", "Average"));
        }

        for (String s : students.keySet()) {
            ArrayList<Double>grades=students.get(s);
            double average = (grades.get(0) + grades.get(1) + grades.get(2)) / 3;
            System.out.println(String.format("%1$-10s|%2$7.2f|%3$7.2f|%4$7.2f|%5$7.4f|", s, grades.get(0),grades.get(1),grades.get(2),average).replace(".",","));
        }
    }
}
