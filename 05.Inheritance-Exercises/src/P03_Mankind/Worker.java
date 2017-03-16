package P03_Mankind;

class Worker extends Human {
    private Double weekSalary;
    private Double workHoursPerDay;

    public Worker(String workerName, String workerLastName, Double salary, Double workHours) {
        super(workerName, workerLastName);
        setWeekSalary(salary);
        setWorkHoursPerDay(workHours);
    }

    @Override
    protected String getLastName() {
        if (super.getLastName().length()<4){
            throw new IllegalArgumentException("Expected length more than 3 symbols!Argument: lastName");
        }else{
            return getLastName();
        }
    }

    private Double getWorkHoursPerDay() {
        return workHoursPerDay;
    }

    private void setWorkHoursPerDay(Double workHoursPerDay) {
        if (workHoursPerDay > 1 && workHoursPerDay < 12) {
            this.workHoursPerDay = workHoursPerDay;
        } else {
            throw new IllegalArgumentException("Expected value mismatch!Argument: workHoursPerDay");
        }
    }

    private Double getWeekSalary() {
        return weekSalary;
    }

    private void setWeekSalary(Double weekSalary) {
        if (weekSalary<=10) {
            throw new IllegalArgumentException("Expected value mismatch!Argument: weekSalary");
        }else {
            this.weekSalary = weekSalary;
        }
    }

    private Double getSalaryPerHour() {
        return weekSalary / workHoursPerDay / 7;
    }

    @Override
    public String toString() {
        return String.format("First Name: %s%nLast Name: %s%nWeek Salary: %.2f%nHours per day: %.2f%nSalary per hour: %.2f%n",
                super.getFirstName(),
                super.getLastName(),
                this.getWeekSalary(),
                this.getWorkHoursPerDay(),
                this.getSalaryPerHour()
        );
    }
}