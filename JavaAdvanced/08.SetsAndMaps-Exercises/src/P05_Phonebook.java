import java.util.HashMap;
import java.util.Scanner;

public class P05_Phonebook {
    public static void main(String[] args) {
        Scanner sc=new Scanner(System.in);
        HashMap<String,String>phonebook=new HashMap<>();

        while (true){
            String input=sc.nextLine();
            if (input.equals("search")){
                while (true) {
                    input = sc.nextLine();
                    if (input.equals("stop")) {
                        break;
                    }
                    if (phonebook.containsKey(input)) {
                        System.out.println(input + " -> " + phonebook.get(input));
                    }else{
                        System.out.println("Contact "+input+" does not exist.");
                    }
                }
                break;
            }
            String[]fix=input.split("-");
            phonebook.put(fix[0],fix[1]);
        }
    }
}
