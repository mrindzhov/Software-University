package P06_FootballTeamGenerator;
public class Player {
    private final int MIN_STAT_THRESHOLD = 0;
    private final int MAX_STAT_THRESHOLD = 100;

    private String name;
    private int number;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    Player(
            String name,
            int endurance,
            int sprint,
            int dribble,
            int passing,
            int shooting) {
        this.setName(name);
        this.setEndurance(endurance);
        this.setSprint(sprint);
        this.setDribble(dribble);
        this.setPassing(passing);
        this.setShooting(shooting);
    }


    public String getName() {
        return this.name;
    }
    private void setName(String name) {
        this.name = name;
    }
    int getNumber() {
        return this.number;
    }

    private void setNumber(int number) {
        this.number = number;
    }
    private void setEndurance(int endurance) {
        if (endurance < MIN_STAT_THRESHOLD || endurance > MAX_STAT_THRESHOLD) {
            throw new IllegalArgumentException(String.format("Endurance should be between %s and %s.", MIN_STAT_THRESHOLD, MAX_STAT_THRESHOLD));
        }

        this.endurance = endurance;
    }

    private void setSprint(int sprint) {
        this.sprint = sprint;
    }

    private void setDribble(int dribble) {
        this.dribble = dribble;
    }

    private void setPassing(int passing) {
        this.passing = passing;
    }

    private void setShooting(int shooting) {
        this.shooting = shooting;
    }

    double getAverageStats() {
        return (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / (double) 5;
    }
}