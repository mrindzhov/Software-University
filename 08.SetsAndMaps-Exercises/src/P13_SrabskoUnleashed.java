import java.util.*;

public class P13_SrabskoUnleashed {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        LinkedHashMap<String, LinkedHashMap<String, Long>> events = new LinkedHashMap<>();

        Integer wrongInputs=0;
        do {
            String[] splitInput = input.split(" ");
            try {
                String[] inputMonkeySplit = input.split("@");
                String singer = inputMonkeySplit[0];
                if (singer.charAt(singer.length() - 1) != ' ') {
                    input = sc.nextLine();
                    continue;
                }
                String[] others = inputMonkeySplit[1].split(" ");

                StringBuilder venueBuilder = new StringBuilder();
                for (int i = 0; i < others.length - 2; i++) {
                    venueBuilder.append(others[i]);
                    venueBuilder.append(" ");
                }

                String venue = venueBuilder.toString().trim();


                //String singer = input.substring(0, input.indexOf("@")).trim();
                Long ticketsCount = Long.valueOf(splitInput[splitInput.length - 1]);
                Long ticketPrice = Long.valueOf(splitInput[splitInput.length - 2]);
                Long totalPrice = ticketPrice * ticketsCount;
                //String venue = input.substring(input.indexOf("@") + 1, input.indexOf(ticketPrice.toString())).trim();
                if (!events.containsKey(venue)) {
                    events.put(venue, new LinkedHashMap<>());
                }

                if (!events.get(venue).containsKey(singer)) {
                    events.get(venue).put(singer, totalPrice);
                } else {
                    Long toAdd = events.get(venue).get(singer) + totalPrice;
                    events.get(venue).put(singer, toAdd);
                }
            } catch (Exception e) {
                wrongInputs++;
            }
            input = sc.nextLine();

        } while (!input.equals("End"));
        for (String s : events.keySet()) {
            System.out.println(s);
            events.get(s).entrySet().stream().sorted(Map.Entry.comparingByValue(Comparator.reverseOrder())).forEach(pair->{
                System.out.printf("#  %s-> %d\n", pair.getKey(), pair.getValue());
            });
        }
    }
}


