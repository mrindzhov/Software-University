package P04_RadioDatabase;

import P04_RadioDatabase.Exceptions.InvalidSongException;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    public static void main(String[] args) throws IOException {

        Database database = new Database();

        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int numberOfSongs = Integer.valueOf(reader.readLine());

        for (int i = 0; i < numberOfSongs; i++) {
            try {
                database.addSong(reader.readLine());
                System.out.println("Song added.");
            } catch (InvalidSongException ise) {
                System.out.println(ise.getMessage());
            }
        }

        System.out.printf("Songs added: %s%n", database.size());
        long totalLength = database.getPlaylistLength();
        long hours = totalLength / 60 / 60;
        long minutes = (totalLength / 60) - (hours * 60);
        long seconds = totalLength % 60;
        System.out.printf("Playlist length: %sh %sm %ss%n", hours, minutes, seconds);
    }
}
