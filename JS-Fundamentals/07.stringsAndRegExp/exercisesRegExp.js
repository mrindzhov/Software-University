function splitWithDelimiter(arr) {
    let text=arr[0];
    let delimiter=arr[1];
    text = text.split(delimiter);
    for (let i = 0; i < text.length; i++) {
        console.log(text[i]);

    }
}
// splitWithDelimiter(['http://platform.softuni.bg', '.']);
function repeatStringNTimes(arr) {
   console.log(arr[0].repeat(Number(arr[1])));
}
// repeatStringNTimes(['repeat','5']);
function startsWith(arr) {
    let text1=arr[0];
    let text2=arr[1];
    let length=text2.length;
    for (let i = 0; i < length; i++) {
        if(text1[i]!=text2[i]){
            return false;
        }
    }
    return true;
}
// startsWith(['Marketing Fundamentals, starting 19/10/2016','Marketing Fundamentals, sta']);
function endsWith(input) {
    let text = input[0];
    let substring = input[1];
    let lenght = substring.length;
    if (text.substring(text.length - lenght, text.length) == substring) {
        return true;
    }
    else {
        return false;
    }
}
// endsWith(['This sentence ends with fun?','fun?']);
function capitalizeWords(arr) {
    let words = String(arr).split(' ');
    for (let i = 0; i < words.length; i++) {
        let str = words[i].toLowerCase();
        words[i] = words[i].charAt(0).toUpperCase() + str.slice(1);
    }
    console.log(words.join(' '));
}
// capitalizeWords(['capital IZE these words']);
function captureTheNumbers(input) {
    let text = input.join('');
    let regex = /\d+/g;
    let numbers=text.match(regex);
    console.log(numbers.join(' '));
}
// captureTheNumbers(['The300 What is that? I think it’s the 3rd movie. Lets watch it at 22:45']);
function variableNameInSentence(input) {
    let text=String(input);
    let regex=/\b_([A-Za-z0-9]*)\b/g;
    let numbers=text.match(regex);
    let extracted=numbers.join(',');
    let newNums="";
    for (let i = 0; i < extracted.length; i++) {
        if(extracted[i]!='_'){
            newNums+=extracted[i];
        }
    }
    console.log(newNums);
}
// variableNameInSentence(['_id ___ __invalidVariable _evenMoreInvalidVariable_ _validVariable']);
function wordOccurrences(arr) {
    let key = arr.pop().toLowerCase();
    let text = arr[0];
    var regex = new RegExp('\\b' + key + '\\b', 'gi');
    let print = text.match(regex);
    if (print!= null)
        console.log(print.length);
    else
        console.log(0);
}
// wordOccurrences(['How do you plan on achieving that?' +
//                 ' How? How can you even think of that?',
//                 'how'
// ]);
function extractLinks(arr) {
    let pattern = /(www\.)([a-zA-Z0-9-]+)(\.[a-z]+)+/g;
    let print = String(arr).match(pattern);
    if(print!=null)
    console.log(print.join('\n'));
}
// extractLinks(
//         ['Join WebStars now for free, at www.web-stars.com',
//         'You can also support our partners:',
//         'Internet - www.internet.com',
//         'WebSpiders - www.webspiders101.com',
//         'Sentinel - www.sentinel.-ko']);
function selectData(input) {
    let f =  input
        .forEach(l => console.log(l
            .replace(
                /(\*[A-Z][a-zA-Z]*)(?= |\t|$)|(\+[0-9-]{10})(?= |\t|$)|(![0-9a-zA-Z]+)(?= |\t|$)|(_[0-9a-zA-Z]+)(?= |\t|$)/g,
                (m) => '|'.repeat(m.length))));
}
// selectData(['Agent *Ivankov was in the room when it all happened.',
//     'The person in the room was heavily armed.',
//     'Agent *Ivankov had to act quick in order.',
//     'He picked up his phone and called some unknown number. ',
//     'I think it was +555-49-796',
//     'I can\'t really remember...',
//     'He said something about "finishing work with subject !2491a23BVB34Q and returning to Base _Aurora21 .',
//     'Then after that he disappeared from my sight.',
//     'As if he vanished in the shadows.',
//     'A moment, shorter than a second, later, I saw the person flying off the top floor.',
//     'I really don\'t know what happened there.',
//     'This is all I saw, that night.',
//     'I cannot explain it myself...']);