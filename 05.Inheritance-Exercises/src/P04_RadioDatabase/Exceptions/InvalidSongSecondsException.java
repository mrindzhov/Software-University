package P04_RadioDatabase.Exceptions;

public class InvalidSongSecondsException extends InvalidSongLengthException{

    public InvalidSongSecondsException(String message) {
        super(message);
    }
}
