function triangleOfStars([a]) {
    [a]=[a].map(Number);
    function printStars(count) {
        console.log('*'.repeat(i));
    }
    for (let i = 1; i <= a; i++) {
        printStars(i);
    }
    for (let i = a-1; i >= 1; i--) {
        printStars(i);
    }
}
// triangleOfStars(['2']);
function squareOfStars([a]) {
    [a]=[a].map(Number);
    for (let i = 0; i < a; i++) {
        console.log('*'+' *'.repeat(a-1));
    }
}
// squareOfStars(['2']);
function isPalindrome([input]) {
    for (let i = 0; i < input.length / 2; i++) {
        if (input[i] != input[input.length - 1 - i]) {
            return false;
        }
        return true;
    }
}
// isPalindrome(['haha']);
function dayOfWeek(day) {
    if (day == 'Monday') return 1;
    if (day == 'Tuesday') return 2;
    if (day == 'Wednesday') return 3;
    if (day == 'Thursday') return 4;
    if (day == 'Friday') return 5;
    if (day == 'Saturday') return 6;
    if (day == 'Sunday') return 7;
    return "error";
}
// dayOfWeek(['Monday']);
function functionalCalc([a,b,op]) {
    [a, b] = [a, b].map(Number);
    let calc = function(a, b, op) { return op(a, b) };
    let add = function(a, b) { return a + b };
    let subtract = function(a, b) { return a - b };
    let multiply = function(a, b) { return a * b };
    let divide = function(a, b) { return a / b };

    switch (op) {
        case '+':
            return calc(a, b, add);
        case '-':
            return calc(a, b, subtract);
        case '*':
            return calc(a, b, multiply);
        case '/':
            return calc(a, b, divide);
    }
}
// functionalCalc(['2','4','+']);
function aggregateElements(input) {
    let elements = input.map(Number);
    aggregate(elements, 0, (a, b) => a + b);
    aggregate(elements, 0, (a, b) => a + 1 / b);
    aggregate(elements, '', (a, b) => a + b);
    function aggregate(arr, initVal, func) {
        let val = initVal;
        for (let i = 0; i < arr.length; i++)
            val = func(val, arr[i]);
        console.log(val);
    }
}
// aggregateElements([10, 20, 30]); // 60 1.833 102030
function wordsUppercase([str]) {
    let strUpper = str.toUpperCase();
    let words = extractWords();
    words = words.filter(w => w != '');
    return words.join(', ');
    function extractWords() { return strUpper.split(/\W+/); }
}
// wordsUppercase(['hello']);