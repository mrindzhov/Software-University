package P04_RadioDatabase.Exceptions;

public class InvalidSongMinutesException extends InvalidSongLengthException{

    public InvalidSongMinutesException(String message) {
        super(message);
    }
}
