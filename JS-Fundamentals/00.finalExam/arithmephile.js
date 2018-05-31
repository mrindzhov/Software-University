function solve(input) {
    let biggestSum = Number.NEGATIVE_INFINITY;
    let numbers = input.map(row => row.split('\n')).map(Number);
    let random = numbers;

    for (let i = 0; i < numbers.length; i++) {
        let currentSum = Number.NEGATIVE_INFINITY;
        if (numbers[i] >= 0 && numbers[i] < 10) {
            for (let currentPos = 1; currentPos <= numbers[i]; currentPos++) {
                let currNum = numbers[i + currentPos];
                if (currentSum == Number.NEGATIVE_INFINITY) {
                    currentSum = currNum;
                }
                else {
                    currentSum *= currNum;
                }
            }
        }
        if (currentSum > biggestSum) {
            biggestSum = currentSum;
        }
    }
    console.log(biggestSum);
}
let input = [`10`, `20`, `2`, `30`, `44`, `123`, `3`, `56`, `20`, `24`];
let input2=["100","200","2","3","2","3","2","1","1"];
solve(input);