"use strict";
function letterOccurrences(input) {

    let word = String(input[0]);
    let b = String(input[1]);
    let occurrences=0;
    for (let i = 0; i < word.length; i++) {
        let element = word[i];
        if(element==b) {
            occurrences++;
        }
    }

    console.log(occurrences);
}
letterOccurrences(['hello','l']);