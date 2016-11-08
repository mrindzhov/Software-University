function queryMess(input) {
    function htmlEscape(text) {
        let map = {'+': '', '%20': ''};
        return text.replace(/([\%20\+]+)/g, ch => map[ch]);
    }
    let pattern = /([a-z]+)(\+\=|\=)([(?:\%20)\+\.\:\/\[a-z0-9\?\]]+)/g;
    for (let i = 0; i < input.length; i++) {
        let currentLine = String(input[i]).match(pattern);
        let print={};

        for (let element = 0; element < currentLine.length; element++) {
            currentLine[element]=htmlEscape(currentLine[element]);
            currentLine[element]=currentLine[element].split('=');
            let key=currentLine[element][0];
            let value=currentLine[element][1];
            if(!print.hasOwnProperty(key)) {
                print[key]=value;
            }
            else{
                print[key]+=", "+value;
            }
        }
        console.log(print);

    }
}
let input=[`foo=%20foo&value=+val&foo+=5+%20+203`, `foo=poo%20&value=valley&dog=wow+`,
    `url=https://softuni.bg/trainings/coursesinstances/details/1070`,
    `https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php`];
queryMess(input);