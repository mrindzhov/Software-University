import java.util.Scanner;

public class P07_CollectCoins {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        char[][] jagged = new char[4][];
        for (int row = 0; row < 4; row++) {
            jagged[row] = scanner.nextLine().toCharArray();
        }
        int row=0;
        int col=0;
        int walls=0;
        int coins=0;
        char[]commands=scanner.nextLine().toCharArray();

        if(jagged[row][col]=='$') {
            coins += 1;
        }
        for (char command : commands) {
            switch (command){
                case'V':
                    row++;
                    try{
                        if(jagged[row][col]=='$'){
                            coins++;
                        }
                    }catch (IndexOutOfBoundsException e){
                        walls++;
                        row--;
                    }
                    break;
                case'>':
                    col++;
                    try {
                        if (jagged[row][col] == '$') {
                            coins++;
                        }
                        break;
                    }catch (IndexOutOfBoundsException e){
                        walls++;
                        col--;
                        break;
                    }
                case'<':
                    col--;
                    try{
                        if(jagged[row][col]=='$'){
                            coins++;
                        }
                    }catch (IndexOutOfBoundsException e){
                        walls++;
                        col++;
                    }
                    break;
                case'^':
                    row--;
                    try{
                        if(jagged[row][col]=='$'){
                            coins++;
                        }
                    }catch (IndexOutOfBoundsException e){
                        walls++;
                        row++;
                    }
                    break;

            }
        }
        System.out.println("Coins = "+coins);
        System.out.println("Walls = "+walls);
    }
}
