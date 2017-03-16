package P03_Mankind;

abstract class Human {
    private String firstName;
    private String lastName;
    Human(String firstName,String lastName) {
        setFirstName(firstName);
        setLastName(lastName);
    }

    protected String getFirstName() {
        return firstName;
    }

    private void setFirstName(String firstName) {
        if (Character.isUpperCase(firstName.charAt(0))) {
            if (firstName.length() >= 4) {
                this.firstName = firstName;
            } else {
                throw new IllegalArgumentException("Expected length at least 4 symbols!Argument: firstName");
            }

        } else {
            throw new IllegalArgumentException("Expected upper case letter!Argument: firstName");
        }
    }

    protected String getLastName() {
        return lastName;
    }

    private void setLastName(String lastName) {

        if (Character.isUpperCase(lastName.charAt(0))) {
            if (lastName.length() >= 3) {
                this.lastName = lastName;
            } else {
                throw new IllegalArgumentException("Expected length at least 3 symbols!Argument: lastName ");
            }

        } else {
            throw new IllegalArgumentException("Expected upper case letter!Argument: lastName");
        }
    }
}
