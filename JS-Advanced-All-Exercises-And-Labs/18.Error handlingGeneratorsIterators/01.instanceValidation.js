class CheckingAccount{
    constructor(clientId, email, firstName, lastName) {
        if (clientId.length != 6) {
            throw new TypeError("Client ID must be a 6-digit number");
        }
        if (!email.match(/([a-zA-Z0-9]+)@([a-zA-Z\.]+)/g)) {
            throw new TypeError("Invalid e-mail");
        }
        if ((firstName.length < 3 || firstName.length > 20)) {
            throw new TypeError("First name must be between 3 and 20 characters long");
        }
        if ((firstName.length < 3 || firstName.length > 20)) {
            throw new TypeError("Last name must be between 3 and 20 characters long");
        }
        if (!firstName.match(/^[a-zA-Z]+$/g)) {
            throw new TypeError("First name must contain only Latin characters");
        }
        if (!lastName.match(/^[a-zA-Z]+$/g)) {
            throw new TypeError("Last name must contain only Latin characters");
        }
        this.products = [];
    }
}
let acc = new CheckingAccount('1314', 'ivan@some.com', 'Ivan', 'Petrov');
let acc1 = new CheckingAccount('131455', 'ivan@', 'Ivan', 'Petrov');
let acc2 = new CheckingAccount('131455', 'ivan@some.com', 'I', 'Petrov');
let acc3 = new CheckingAccount('131455', 'ivan@some.com', 'Ivan', 'P3trov');