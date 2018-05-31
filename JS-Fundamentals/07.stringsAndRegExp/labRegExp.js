function printStringLetters(str) {
    if (Array.isArray(str))
        str = str[0]; // Take the first element
    for (let i in str)
        console.log(
            `str[${i}] -> ${str[i]}`);
}
// printStringLetters('Hello');
// printStringLetters(['SoftUni']);
function concatenateAndReverse(arr) {
    let allStrings = arr.join('');
    let chars = Array.from(allStrings);
    let revChars = chars.reverse();
    let revStr = revChars.join('');
    return revStr;
}
// concatenateAndReverse(['I', 'am', 'student']);
function countStringInText([str, text]) {
    let count = 0;
    let index = text.indexOf(str);
    while (index > -1) {
        count++;
        index = text.indexOf(str, index + 1);
    }
    return count;
}
// countStringInText(['am', 'I am cool. Bam']); // 2
function extractText([str]) {
    let result=[];
    let startIdx=str.indexOf('(');
    while(startIdx>-1){
        let endIdx=str.indexOf(')',startIdx);
        if(endIdx==-1){
            break;
        }
        let snippet=str.substring(startIdx+1,endIdx);
        result.push(snippet);
        startIdx=str.indexOf('(',endIdx);
    }
    console.log(result.join(', '));
}
// extractText(['Rakiya (Bulgarian brandy) is home-made liquor (alcoholic drink). ' +
// 'It can be made of grapes, plums or other fruits (even apples).']);
function aggregateTable(lines) {
    let sum = 0, list = [];
    for (let line of lines) {
        let townData = line.split('|'),
            townName = townData[1].trim(),
            income = Number(townData[2].trim());
        list.push(townName);
        sum += income;
    }
    console.log(list.join(', ') + '\n' + sum);
}
// aggregateTable(['| Sofia      | 300',
//                 '| Plovdiv    | 500',
//                 '| Varna      | 200',
//                 '| Yambol     | 275',]);
function printBill(input) {
    let items = input.filter((x, i) => i % 2 == 0);
    let sum = input
        .filter((x, i) => i % 2 == 1)
        .map(Number)
        .reduce((a, b) => a + b);
    console.log(`You purchased ${items.join(', ')} for a total sum of ${sum}`);
}
// printBill(['Cola','1.35', 'Pancakes', '2.88']);
function extractUserName(emails) {
    let result=[];
    for (let email of emails) {
        let [alias,domain]=email.split('@');
        let username=alias+'.';
        let domainParts=domain.split('.');
        domainParts.forEach(p=>username+=p[0]);
        result.push(username);
    }
    return result.join(', ');
}
// console.log(extractText(['pesho@gmail.com', 'tod_or@mail.dir.bg']));
function censorShip(arr) {
    let text=arr[0];
    arr.shift();
    for(let word of arr){
        let replaced = '-'.repeat(word.length);
        while(text.indexOf(word)>-1){
            text=text.replace(word,replaced);
        }
    }
    console.log(text);
}
// censorShip(['I like C#, HTML, JS and PHP',
//     'C#', 'HTML', 'PHP']);
function escaping(arr) {
    let html = '<ul>\n';

    for (let line of arr) {
        html += '\t<li>';
        html += htmlEscape(line);
        html += '</li>\n';
    }
    html += '</ul>';
    console.log(html);
    function htmlEscape(text) {
        let map = {
            '"': '&quot;', '&': '&amp;',
            "'": '&#39;', '<': '&lt;', '>': '&gt;'
        };
        return text.replace(/[\"&'<>]/g, ch => map[ch]);
    }
}
// escaping([`"Hello", he said`,
// `<script>alert('hi');</script>`,
// `Use the <div> tag.`
// ]);
function matchAllWords(input){
    let text = input[0].match(/\w+/g);
    console.log(text.join('|'));
}
// matchAllWords(['_(Underscores) are also word characters']);
function validateEmail([email]) {
    let pattern =/^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,20}$/i;
    let result = pattern.test(email);
    if (result) {
        console.log("Valid");
    } else {
        console.log("Invalid");
    }
}
// validateEmail(['bai.ivan@mail.sf.net']);
function expressionSplit(arr) {
    let expression = arr[0];
    console.log(expression);
    let elements = expression
        .split(/[\s.();,]+/);
    console.log(elements.join("\n"));

}
// expressionSplit(['let sum = 4 * 4,b = "wow";']);
function matchDates(arr) {
    let pattern =
        /\b([0-9]{1,2})-([A-Z][a-z]{2})-([0-9]{4})\b/g;
    let dates = [], match;
    for (let sentence of arr)
        while (match = pattern.exec(sentence))
            dates.push(`${match[0]} (Day: ${match[1]}, Month: ${match[2]}, Year: ${match[3]})`);
    console.log(dates.join("\n"));
}
// matchDates(['1-Jun-2012 is before 14-Feb-2016']);
function employeeData(input) {
    let pattern=/^([A-Z][a-zA-Z]*) - ([1-9][0-9]*) - ([a-zA-Z0-9 -]+)$/;
    for (let element of input) {
        let match = pattern.exec(element);
        if (match)
            console.log(`Name: ${match[1]}\n` +
                `Position: ${match[3]}\n` +
                `Salary: ${match[2]} `);
    }
}
// employeeData(['Jeff - 1500 - Staff', 'Ko - 150 - Ne']);
function fillForm(data) {
    let [username, email, phone] =
        [data.shift(), data.shift(), data.shift()];

    data.forEach(line => {
                 line = line.replace(/<![a-zA-Z]+!>/g, username);
                 line = line.replace(/<@[a-zA-Z]+@>/g, email);
                 line = line.replace(/<\+[a-zA-Z]+\+>/g, phone);
                 console.log(line);
    });
}
// fillForm(['pit', 'pit@pit.com', '032746',
//     'I am <!user!>, my email is <@email@>, my phone is <+p+>.']);
function performMultiplications([text]) {
    text=text.replace(/(-?\d+)\s*\*\s*(-?\d+(\.\d+)?)/g,(match,num1,num2)=>Number(num1)*Number(num2));
    console.log(text);
}
// performMultiplications(['My bill: 2*2.50 (beer)']);