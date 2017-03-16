package P04_RadioDatabase.Exceptions;

public class InvalidSongException extends RuntimeException {
    public InvalidSongException(String message) {
        super(message);
    }
}
