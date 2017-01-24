import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Scanner;

public class P06_Robotics {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] robots = scanner.nextLine().split(";");
        String[] robotNames = new String[robots.length];
        int[] processTimes = new int[robots.length];
        int[] robotCounters = new int[robots.length];
        for (int i = 0; i < robots.length; i++) {
            String[] robotArgs = robots[i].split("-");
            robotNames[i] = robotArgs[0];
            processTimes[i] = Integer.valueOf(robotArgs[1]);
            robotCounters[i] = 0;
        }
        String[] timeArgs = scanner.nextLine().split(":");
        int hh = Integer.valueOf(timeArgs[0]) * 60 * 60;
        int mm = Integer.valueOf(timeArgs[1]) * 60;
        int ss = Integer.valueOf(timeArgs[2]);
        int time = hh + mm + ss;
        Deque<String> products = new ArrayDeque<>();
        while (true) {
            String product = scanner.nextLine();
            if (product.equals("End")) {
                break;
            }
            products.offer(product);
        }
        while (!products.isEmpty()){
            for (int i = 0; i < robots.length; i++) {
                if(robotCounters[i]>0){
                    robotCounters[i]--;
                }
            }
            time++;
            String currentProduct=products.poll();
            boolean isProductTaken=false;
            for (int i = 0; i < robots.length; i++) {
                if(robotCounters[i]==0) {
                    robotCounters[i] = processTimes[i];
                    System.out.printf("%s - %s [%s]%n", robotNames[i], currentProduct, getTime(time));
                    isProductTaken = true;
                    break;
                }
            }
            if(!isProductTaken) {
                products.offer(currentProduct);
            }
        }
    }
    private static String getTime(long time) {
        String hours = String.format("%2s", (time / 60 / 60) % 24).replace(' ', '0');
        String minutes = String.format("%2s", (time / 60) % 60).replace(' ', '0');
        String seconds = String.format("%2s", time % 60).replace(' ', '0');
        return String.format("%s:%s:%s", hours, minutes, seconds);
    }
}
