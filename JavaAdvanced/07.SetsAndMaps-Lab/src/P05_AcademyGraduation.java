import java.util.Scanner;
import java.util.TreeMap;

public class P05_AcademyGraduation {
    private static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        int numberOfStudents = Integer.parseInt(scanner.nextLine());
        TreeMap<String,Double[]> students= new TreeMap<>();
        for (int i = 0; i < numberOfStudents; i++) {
            String name = scanner.nextLine();
            String[] scoresStrings = scanner.nextLine().split(" ");
            Double[] scores = new Double[scoresStrings.length];

            for (int j = 0; j < scoresStrings.length; j++) {
                scores[j] = Double.parseDouble(scoresStrings[j]);
            }
            students.put(name, scores);
        }

        for (String s : students.keySet()) {
            Double sum=0d;
            for (Double aDouble : students.get(s)) {
                sum+=aDouble;
            }
            System.out.println(s+" is graduated with "+sum/students.get(s).length);
        }
    }
}
