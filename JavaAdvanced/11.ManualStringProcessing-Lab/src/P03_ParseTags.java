import java.util.Scanner;

public class P03_ParseTags {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        String upCase = "<upcase>";
        String upCaseStop = "</upcase>";

        while (input.contains(upCase)) {
            int startIndex = input.indexOf(upCase);
            int endIndex = input.indexOf(upCaseStop);

            String reminder = input.substring(startIndex + 8, endIndex);
            String upRem = reminder.toUpperCase();
            input = input.replaceFirst(reminder, upRem);
            input = input.replaceFirst(upCase, "");
            input = input.replaceFirst(upCaseStop, "");
        }

        System.out.println(input);
    }
}
