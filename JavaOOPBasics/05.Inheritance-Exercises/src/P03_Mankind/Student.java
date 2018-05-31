package P03_Mankind;

class Student extends Human {
    private String  facultyNumber;

    public Student(String studentName, String studentLastName, String facultyNumber) {
        super(studentName, studentLastName);
        setFacultyNumber(facultyNumber);
    }

    private String getFacultyNumber() {
        return facultyNumber;
    }

    private void setFacultyNumber(String  facultyNumber) {
        if (facultyNumber.length() < 5 || facultyNumber.length() > 10) {
            throw new IllegalArgumentException("Invalid faculty number!");
        } else {
            this.facultyNumber = facultyNumber;
        }
    }

    @Override
    public String toString() {
        return String.format("First Name: %s%nLast Name: %s%nFaculty number: %s%n",
                super.getFirstName(),
                super.getLastName(),
                this.getFacultyNumber()
        );
    }
}
