function big3Nums([a,b,c]) {
    [a,b,c]=[a,b,c].map(Number);
    console.log(Math.max(a,b,c));
}
// big3Nums([5,-2,7]);

function pointInRec(input) {
    let [x,y,xMin,xMax,yMin,yMax]=input.map(Number);
    if (x <= xMax && x >= xMin && y<=yMax && y >= yMin) {
        console.log('inside');
    }
    else
        console.log('outside');
}

function oddNumbers1toN(input) {
    let [a]=input.map(Number);
    for (let i = 0; i <= a; i++) {
        if(i%2==1){
            console.log(i);
        }
    }
}
function triangleOfDollars(input) {
    let [a]=input.map(Number);
    for (let i = 1; i <= a; i++) {
        console.log('$'.repeat(i));
    }
}
// triangleOfDollars([5]);
function moviePrices([filmName,day]) {
    filmName=filmName.toLowerCase();
    day=day.toLowerCase();
    if(filmName==`the godfather`) {
        switch (day) {
            case 'monday':console.log(12);break;
            case 'tuesday':console.log(10);break;
            case 'wednesday':console.log(15);break;
            case 'thursday':console.log(12.50);break;
            case 'friday':console.log(15);break;
            case 'saturday':console.log(25);break;
            case 'sunday':console.log(30);break;
            default:console.log('error');break;
        }
    }
    else if(filmName==`schindler's list`){
        switch (day) {
            case 'monday':console.log(8.50);break;
            case 'tuesday':console.log(8.50);break;
            case 'wednesday':console.log(8.50);break;
            case 'thursday':console.log(8.50);break;
            case 'friday':console.log(8.50);break;
            case 'saturday':console.log(15);break;
            case 'sunday':console.log(15);break;
            default:console.log('error');break;
        }
    }
    else if(filmName==`casablanca`){
        switch (day) {
            case 'monday':console.log(8);break;
            case 'tuesday':console.log(8);break;
            case 'wednesday':console.log(8);break;
            case 'thursday':console.log(8);break;
            case 'friday':console.log(8);break;
            case 'saturday':console.log(10);break;
            case 'sunday':console.log(10);break;
            default:console.log('error');break;
        }
    }
    else if(filmName==`the wizard of oz`){
        switch (day) {
            case 'monday':console.log(10);break;
            case 'tuesday':console.log(10);break;
            case 'wednesday':console.log(10);break;
            case 'thursday':console.log(10);break;
            case 'friday':console.log(10);break;
            case 'saturday':console.log(15);break;
            case 'sunday':console.log(15);break;
            default:console.log('error');break;
        }
    }
    else {
            console.log('error');
    }
}
// moviePrices([`Casablanca`,`Wednesday`]);
function quadraticEquation([a,b,c]) {
    [a, b, c] = [a, b, c].map(Number);
    let discriminant = Math.pow(b, 2) - (4 * a * c);
    if (discriminant > 0) {
        let x2 = (-b - Math.sqrt(discriminant)) / (2 * a);
        let x1 = (-b + Math.sqrt(discriminant)) / (2 * a);
        console.log(x2);
        console.log(x1);
    }
    else if(discriminant==0){
        let x = (-b + Math.sqrt(discriminant)) / (2 * a);
        console.log(x);
    }
    else
        console.log(`No`);
}
// quadraticEquation([6,11,-35]);
function multiplicationTable([a]) {
    [a] = [a].map(Number);
    console.log(`<table border="1">`);
    console.log(`<tr>`);
    console.log(`<th>"x"</th>`);
    for (let i = 1; i <= a; i++) {
        console.log(`<th>`+i+`</th>`);
    }
    console.log(`</tr>`);
    for (let i = 1; i <= a; i++) {
        console.log(`<tr>`);
        console.log(`<th>`+i+`</th>`);

        for (let j = 1; j <= a; j++) {
            console.log(`<td>`+j*i+`</td>`);
        }
        console.log(`</tr>`);
    }
    console.log(`</table>`);
}
 // multiplicationTable([5]);

function figureOf4Squares([num]) {
    [num]=[num].map(Number);

    if(num==2) {
        console.log('+++');
        return;
    }
        console.log(`+`+`-`.repeat(num-2)+`+`+`-`.repeat(num-2)+`+`);


    if(num>4) {
        if (num % 2 == 0) {
            for (let i = 0; i < (num - 4)/2; i++) {
                console.log((`|`+` `.repeat(num-2)+`|`+` `.repeat(num-2)+`|`));
            }
        }
        else if (num % 2 == 1) {
            for (let i = 0; i < (num - 3)/2; i++) {
                console.log((`|`+` `.repeat(num-2)+`|`+` `.repeat(num-2)+`|`));
            }
        }
    }
    console.log(`+`+`-`.repeat(num-2)+`+`+`-`.repeat(num-2)+`+`);
    if(num>4) {
        if (num % 2 == 0) {
            for (let i = 0; i < (num - 4)/2; i++) {
                console.log((`|`+` `.repeat(num-2)+`|`+` `.repeat(num-2)+`|`));
            }
        }
        else if (num % 2 == 1) {
            for (let i = 0; i < (num - 3)/2; i++) {
                console.log((`|`+` `.repeat(num-2)+`|`+` `.repeat(num-2)+`|`));
            }
        }
    }
    console.log(`+`+`-`.repeat(num-2)+`+`+`-`.repeat(num-2)+`+`);
}
// figureOf4Squares([2]);