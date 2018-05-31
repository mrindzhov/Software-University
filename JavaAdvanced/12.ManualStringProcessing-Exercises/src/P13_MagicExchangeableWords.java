import java.util.HashMap;
import java.util.Scanner;

public class P13_MagicExchangeableWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        HashMap<Character, Character> charMap = new HashMap<>();
        String longerStr = scanner.next();
        String shorterStr = scanner.next();
        if (longerStr.length() < shorterStr.length()) {
            String temp = shorterStr;
            shorterStr = longerStr;
            longerStr = temp;
        }
        boolean isMagic = isMagic(charMap, longerStr, shorterStr);
        System.out.println(isMagic);

    }

    private static boolean isMagic(HashMap<Character, Character> charMap, String longerStr, String shorterStr) {
        boolean isMagic=true;
        for (int i = 0; i < shorterStr.toCharArray().length; i++) {
            if (!charMap.containsKey(longerStr.charAt(i))) {
                charMap.put(longerStr.charAt(i), shorterStr.charAt(i));
            } else if (charMap.get(longerStr.charAt(i)) != shorterStr.charAt(i)) {
                isMagic = false;
                break;
            }
        }
        if (isMagic) {
            for (int i = shorterStr.length(); i < longerStr.length(); i++) {
                if(!charMap.containsKey(longerStr.charAt(i))){
                    isMagic=false;
                    break;
                }
            }
        }
        return isMagic;
    }
}

