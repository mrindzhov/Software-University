function solve(input) {
    function htmlEscape(text) {
        let map = {
            '!': '1', '#': '3',
            "$": '4', '%': '2'
        };
        return text.replace(/[\!\#\$\%]/g, ch => map[ch]);
    }

    let key = input.shift().toLowerCase();
    let regexKey = (new RegExp(key, 'gi'));
    let regexWord = regexKey + /(?:\s+)([A-Z\!\#\$\%]+)(?:\s+|\.|\,|\z)/g;
    for (let line = 0; line < input.length; line++) {
        let currentLine = String(input[line]);
        if (currentLine.match(new RegExp(regexWord, 'g')) == null) {
            console.log(currentLine);
        } else {
            let word = String(currentLine.match(regexWord));
            console.log(word);
            console.log(word.replace(word, htmlEscape(word).toLowerCase()));
            console.log(currentLine.replace(word, htmlEscape(word).toLowerCase()));
        }
    }
}
let input = ["specialKey",
    "In this text the specialKey HELLOWORLD! is correct, but",
    "the following specialKey $HelloWorl#d and spEcIaLKEy HOLLOWORLD1 are not, while",
    "SpeCIaLkeY   SOM%%ETH$IN and SPECIALKEY ##$$##$$ are!"];
let input2=["enCode",
    "Some messages are just not encoded what can you do?",
    "RE - ENCODE THEMNOW! - he said.",
    "Damn encode, ITSALLHETHINKSABOUT, eNcoDe BULL$#!%."];
solve(input);

