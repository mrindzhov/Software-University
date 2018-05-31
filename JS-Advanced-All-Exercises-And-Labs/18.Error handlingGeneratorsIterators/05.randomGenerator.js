function* random(num) {
    let formula = Math.pow(num, 2) % 38573449;
    let randomNum = formula % 100;

    while (true) {
        yield randomNum;
        num=Math.pow(formula,2);
        formula=num%38573449;
        randomNum=formula%100;
    }
}
/*
let rnd = random(100);

for (let i = 0; i < 10; i++) {
    console.log(rnd.next().value);
}
*/
