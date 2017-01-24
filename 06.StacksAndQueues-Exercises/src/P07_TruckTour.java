import java.util.ArrayDeque;
import java.util.Queue;
import java.util.Scanner;

public class P07_TruckTour {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());

        Queue<GasPump> pumps = new ArrayDeque<>();


        for (int i = 0; i < n; i++) {
            String[] pumpArgs = scanner.nextLine().split(" ");
            pumps.add(new GasPump(Integer.parseInt(pumpArgs[0]), Integer.parseInt(pumpArgs[1])));
        }
        Queue<GasPump> originalPumps = new ArrayDeque<>(pumps);
        Queue<GasPump> previousPumps = new ArrayDeque<>();
        GasPump starterPump = null;
        boolean tvaE = false;
        int gasInTank = 0;
        int indexOfPump = 0;
        int counter = 0;
        int counterAddUp = 1;
        while (pumps.size() > 0 || counter >= pumps.size()) {
            GasPump currentPump = pumps.remove();
            starterPump = currentPump;
            pumps.add(currentPump);
            gasInTank += currentPump.amountOfGas;
            while (gasInTank >= currentPump.distanceToNext) {
                gasInTank -= currentPump.distanceToNext;
                currentPump = pumps.remove();
                counterAddUp++;
                if (currentPump == starterPump) {
                    tvaE = true;
                    break;
                }
                pumps.add(currentPump);
                gasInTank += currentPump.amountOfGas;

            }
            if (tvaE) {
                break;
            }
            gasInTank = 0;
            counter += counterAddUp;
            counterAddUp = 1;
        }
        System.out.println(counter);
    }

    private static class GasPump {

        int amountOfGas;
        int distanceToNext;

        GasPump(int amountOfGas, int distanceToNext) {
            this.amountOfGas = amountOfGas;
            this.distanceToNext = distanceToNext;
        }

        @Override
        public String toString() {
            String info = String.format("GAS: %s; DISTANCE%s", this.amountOfGas, this.distanceToNext);
            return info;
        }
    }

}

