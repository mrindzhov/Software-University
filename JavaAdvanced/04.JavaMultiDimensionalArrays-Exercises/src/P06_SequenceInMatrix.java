import java.util.ArrayList;
import java.util.Scanner;

public class P06_SequenceInMatrix {
    private static int countMax = 0;
    private static String result = "";

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        String[][] matrix = new String[Integer.parseInt(input[0])][Integer.parseInt(input[1])];

        for (int i = 0; i < matrix.length; i++) {
            String[] reminder = scanner.nextLine().split(" ");
            for (int j = 0; j < matrix[0].length; j++) {
                matrix[i][j] = reminder[j];
            }
        }

        ArrayList<String> reminder = new ArrayList<>();
        int diagSize = Math.min(Integer.parseInt(input[0]), Integer.parseInt(input[1]));
        for (int i = 0; i < diagSize; i++) {
            reminder.add(matrix[i][i]);
        }
        checkForSequence(reminder);

        reminder.clear();
        for (int i = 0; i < diagSize; ++i) {
            reminder.add(matrix[i][diagSize - i - 1]);
        }
        checkForSequence(reminder);

        for (int i = 0; i < matrix.length; i++) {
            reminder.clear();
            for (int j = 0; j < matrix[0].length; j++) {
                reminder.add(matrix[i][j]);
            }
            checkForSequence(reminder);
        }

        for (int i = 0; i < matrix[0].length; i++) {
            reminder.clear();
            for (int j = 0; j < matrix.length; j++) {
                reminder.add(matrix[j][i]);
            }
            checkForSequence(reminder);
        }

        for (int i = 0; i < countMax; i++) {
            System.out.print(result + ", ");
        }
    }

    private static void checkForSequence(ArrayList<String> list) {
        for (int startPosition = 0; startPosition < list.size() - 1; startPosition++) {
            int count = 1;
            String str = "";
            int currentPosition = startPosition + 1;
            while (list.get(startPosition).equals(list.get(currentPosition))) {
                count += 1;
                str = list.get(startPosition);
                currentPosition += 1;
                if (count >= countMax) {
                    countMax = count;
                    result = str;
                }
                if (currentPosition >= list.size()) {
                    break;
                }
            }
        }
    }
}
