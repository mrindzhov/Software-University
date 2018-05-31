'use strict';
function stringOfNumbers(input) {

    let number = Number(input[0]);
    let string = "";
    for (let i = 1; i <= number; i++) {
        let temp = i;
        string+=temp;
    }
    console.log(string);
}
stringOfNumbers(['11']);