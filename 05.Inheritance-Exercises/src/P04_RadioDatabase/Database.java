package P04_RadioDatabase;

import java.util.ArrayList;
import java.util.List;

public class Database {
    private List<Song> songs;

    public Database() {
        this.songs = new ArrayList<>();
    }

    public int size() {
        return this.songs.size();
    }

    public long getPlaylistLength() {
        long totalLength = 0;
        for (Song song : songs) {
            totalLength += song.getLength();
        }

        return totalLength;
    }

    public void addSong(String songInfo) {
        String[] songTokens = songInfo.split(";");
        String artistName = songTokens[0];
        String songName = songTokens[1];
        String songLength = songTokens[2];

        Song song = new Song(artistName, songName, songLength);
        this.songs.add(song);
    }
}