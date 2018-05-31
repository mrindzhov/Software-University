import java.util.Scanner;

public class P08_MatrixShuffling {
    public static void main(String[] args) {
        Scanner scanner=new Scanner(System.in);
        String[]size=scanner.nextLine().split(" ");
        int rows=Integer.parseInt(size[0]);
        int cols=Integer.parseInt(size[1]);
        String[][] matrix=new String[rows][cols];
        for (int row = 0; row < matrix.length; row++) {
            matrix[row] = scanner.nextLine().split(" ");
        }
        while(true){
            String[] currLine=scanner.nextLine().split(" ");
            if(currLine[0].equals("END"))
            {
                break;
            }else if(currLine[0].equals("swap")){
                int row1=Integer.parseInt(currLine[1]);
                int col1=Integer.parseInt(currLine[2]);
                int row2=Integer.parseInt(currLine[3]);
                int col2=Integer.parseInt(currLine[4]);
                try{
                    String temp=matrix[row1][col1];
                    matrix[row1][col1]=matrix[row2][col2];
                    matrix[row2][col2]=temp;
                    for (int row = 0; row < matrix.length; row++) {
                        for (int col = 0; col < matrix[row].length; col++) {
                            System.out.print(matrix[row][col]+" ");
                        }
                        System.out.println();
                    }
                }catch(IndexOutOfBoundsException e){
                    System.out.println("Invalid input!");
                }
            }
            else{
                System.out.println("Invalid input!");
            }
        }
    }
}


//public class P08_MatrixShuffling {
//    public static void main(String[] args) {
//        Scanner scanner = new Scanner(System.in);
//        String[] input = scanner.nextLine().split(" ");
//        String[][] matrix = new String[Integer.parseInt(input[0])][Integer.parseInt(input[1])];
//
//        for (int i = 0; i < matrix.length; i++) {
//            String[] reminder = scanner.nextLine().split(" ");
//            for (int j = 0; j < matrix[0].length; j++) {
//                matrix[i][j] = reminder[j];
//            }
//        }
//
//        while (true) {
//            String cmd = scanner.nextLine();
//            if (cmd.equals("END")) {
//                break;
//            }
//            String[] command = cmd.split(" ");
//            if (command.length != 5) {
//                System.out.println("Invalid input!");
//                continue;
//            }
//            if (!command[0].equals("swap")) {
//                System.out.println("Invalid input!");
//                continue;
//            }
//            if (Integer.parseInt(command[1]) >= matrix.length || Integer.parseInt(command[1]) < 0 ||
//                    Integer.parseInt(command[3]) >= matrix.length || Integer.parseInt(command[3]) < 0) {
//                System.out.println("Invalid input!");
//                continue;
//            }
//            if (Integer.parseInt(command[2]) >= matrix[0].length || Integer.parseInt(command[4]) < 0 ||
//                    Integer.parseInt(command[4]) >= matrix[0].length || Integer.parseInt(command[4]) < 0) {
//                System.out.println("Invalid input!");
//                continue;
//            }
//
//            String reminder = matrix[Integer.parseInt(command[1])][Integer.parseInt(command[2])];
//            matrix[Integer.parseInt(command[1])][Integer.parseInt(command[2])] = matrix[Integer.parseInt(command[3])][Integer.parseInt(command[4])];
//            matrix[Integer.parseInt(command[3])][Integer.parseInt(command[4])] = reminder;
//
//            for (String[] rows : matrix) {
//                for (String row : rows) {
//                    System.out.print(row + " ");
//                }
//                System.out.println();
//            }
//        }
//    }
//}
