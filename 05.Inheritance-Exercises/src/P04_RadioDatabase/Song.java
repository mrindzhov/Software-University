package P04_RadioDatabase;

import P04_RadioDatabase.Exceptions.*;

public class Song {
    private String artistName;
    private String songName;
    private int minutes;
    private int seconds;
    private String artist;

    public Song(String artistName, String songName, String length) {
        this.setArtistName(artistName);
        this.setSongName(songName);
        this.setLength(length);
    }

    public int getLength() {
        return (this.minutes * 60) + this.seconds;
    }

    private void setArtistName(String artist) {
        if (artist.length() < 3 || artist.length() > 20) {
            throw new InvalidArtistNameException("Artist name should be between 3 and 20 symbols.");
        }

        this.artist = artist;
    }

    private void setSongName(String songName) {
        if (songName.length() < 3 || songName.length() > 20) {
            throw new InvalidSongNameException("Song name should be between 3 and 30 symbols.");
        }

        this.artist = artist;
    }

    private void setLength(String length) {
        String[] lengthTokens = length.split(":");
        int minutes;
        int seconds;
        try {
            minutes = Integer.valueOf(lengthTokens[0]);
            seconds = Integer.valueOf(lengthTokens[1]);
        } catch (NumberFormatException nfe) {
            throw new InvalidSongLengthException("Invalid song length.");
        }

        this.setMinutes(minutes);
        this.setSeconds(seconds);
    }

    private void setMinutes(int minutes) {
        if (minutes < 0 || minutes > 14) {
            throw new InvalidSongMinutesException("Song minutes should be between 0 and 14.");
        }

        this.minutes = minutes;
    }

    private void setSeconds(int seconds) {
        if (seconds < 0 || seconds > 59) {
            throw new InvalidSongSecondsException("Song seconds should be between 0 and 59.");
        }

        this.seconds = seconds;
    }
}