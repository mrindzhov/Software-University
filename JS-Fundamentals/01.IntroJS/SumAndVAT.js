"use strict";
function sumAndVAT(input) {
    let sum = 0;
    let vatSum = 0;

    for (let i = 0; i < input.length; i++) {
        let a = Number(input[i]);
        sum += a;
        vatSum += a * 0.2;
    }
    let vat=sum*0.2;
    let total = sum + vatSum;

    console.log(`sum = ${sum}`);
    console.log(`VAT = ${vat}`);
    console.log(`total = ${total}`);
}
sumAndVAT(['99.9999', '99.9999', '99.9999', '99.9999', '99.9999', '99.9999', '99.9999','99.9999']);