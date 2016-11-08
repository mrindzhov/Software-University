function insideVolume(input) {

    for (let i = 0; i < input.length; i += 3) {
        let x = input[i];
        let y = input[i + 1];
        let z = input[i + 2];
        if (inVolume(x, y, z)) {
            console.log('inside');
        }
        else {
            console.log('outside');
        }
    }

    function inVolume(x, y, z) {
        let x1 = 10, x2 = 50;
        let y1 = 20, y2 = 80;
        let z1 = 15, z2 = 50;
        if (x >= x1 && x <= x2) {
            if (y >= y1 && y <= y2) {
                if (z >= z1 && z <= z2) {
                    return true;
                }
            }
        }
        return false;
    }
}
// insideVolume([8, 20, 22]);
function roadRadar(input) {
    let speed = input[0];
    let area = input[1];
    let limit = getLimit(area);
    let infraction = getInfraction(speed, limit);
    if (infraction) {
        console.log(infraction);
    }
    function getLimit(area) {
        switch (area) {
            case 'motorway':
                return 130;
            case 'city':
                return 50;
            case 'interstate':
                return 90;
            case 'residential':
                return 20;
        }
    }

    function getInfraction(speed, limit) {
        let overSpeed = speed - limit;
        if (overSpeed <= 0) {
            return false;
        }
        else {
            if (overSpeed <= 20) {
                return 'speeding';
            }
            if (overSpeed <= 40) {
                return 'excessive speeding';
            }
            if (overSpeed > 40) {
                return 'reckless driving';
            }
        }
    }
}
// roadRadar([21,'residential']);
function templateFormatting(input) {
    console.log('<?xml version="1.0" encoding="UTF-8"?>');
    console.log('<quiz>');
    for (let i = 0; i < input.length; i += 2) {
        console.log(`\t<question>\n\t\t` + input[i] + `\n\t</question>`);
        console.log(`\t<answer>\n\t\t` + input[i + 1] + `\n\t</answer>`);
    }
    console.log('</quiz>');
}
// templateFormatting(["Dry ice is a frozen form of which gas?", "Carbon Dioxide", "What is the brightest star in the night sky?", "Sirius"]);
function cookingByNumbers(input) {
    let num = Number(input[0]);
    for (let i = 1; i < input.length; i++) {
        let func = input[i];
        activities(func);

    }
    function activities(func) {

        if (func == 'dice') {
            num = Math.sqrt(num);
        }
        if (func == 'chop') {
            num /= 2;
        }
        if (func == 'spice') {
            num++;
        }
        if (func == 'bake') {
            num *= 3;
        }
        if (func == 'fillet') {
            num *= 0.8;
        }
        console.log(num);
    }
}
// cookingByNumbers([9, 'dice', 'spice', 'chop', 'bake', 'fillet']);
function modifyAverage(input) {
    let num = String(input[0]);
    let sum = 0;
    while (true) {
        for (let i = 0; i < num.length; i++) {
            let element = Number(num[i]);
            console.log(element);
            sum += element;
        }
        if (sum / (num.length) > 5) {console.log(num);break;
        }
        else {num += 9;}
        sum = 0;
    }
}
// modifyAverage([101]);
function validityChecker(input) {
    let x1 = Number(input[0]);
    let y1 = Number(input[1]);
    let x2 = Number(input[2]);
    let y2 = Number(input[3]);

    let distanceTo01 = Math.sqrt(Math.pow(x1, 2) + Math.pow(y1, 2));
    if (distanceTo01 === parseInt(distanceTo01)) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    }
    else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    let distanceTo02 = Math.sqrt(Math.pow(x2, 2) + Math.pow(y2, 2));
    if (distanceTo02 === parseInt(distanceTo02)) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    }
    else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    let distanceBetweenPoints = Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
    if (distanceBetweenPoints === parseInt(distanceBetweenPoints)) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    }
    else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}
// validityChecker(['3','0','0','4']);
function treasureLocator(input) {
    for (let i = 0; i < input.length; i += 2) {
        let x = Number(input[i]);
        let y = Number(input[i + 1]);
        if (1 <= x && x <= 3 && 1 <= y && y <= 3) {
            console.log('Tuvalu');
        }
        else if (8 <= x && x <= 9 && 0 <= y && y <= 1) {
            console.log('Tokelau');
        }
        else if (0 <= x && x <= 2 && 6 <= y && y <= 8) {
            console.log('Tonga');
        }
        else if (5 <= x && x <= 7 && 3 <= y && y <= 6) {
            console.log('Samoa');
        }
        else if (4 <= x && x <= 9 && 7 <= y && y <= 8) {
            console.log('Cook');
        }
        else {
            console.log('On the bottom of the ocean');
        }
    }
}
// treasureLocator([4, 2, 1.5, 6.5, 1, 3]);

function tripLength(input) {
    let x1 = Number(input[0]);
    let y1 = Number(input[1]);
    let x2 = Number(input[2]);
    let y2 = Number(input[3]);
    let x3 = Number(input[4]);
    let y3 = Number(input[5]);

    // let distance0a1=Math.sqrt(Math.pow(x1-x2,2)+Math.pow(y1-y2,2));
    // let distance1a2=Math.sqrt(Math.pow(x2-x3,2)+Math.pow(y2-y3,2));
    // let distance2a3=Math.sqrt(Math.pow(x3-x1,2)+Math.pow(y3-y1,2))

    let x = 0;
    let y = 0;


    let distanceTo01 = Math.sqrt(Math.pow(x1, 2) + Math.pow(y1, 2));
    let distanceTo02 = Math.sqrt(Math.pow(x2, 2) + Math.pow(y2, 2));
    let distanceTo03 = Math.sqrt(Math.pow(x3, 2) + Math.pow(y3, 2));
    let firstPoint = Math.min(distanceTo01,distanceTo02,distanceTo03);
    let obj={1:distanceTo01,2:distanceTo02,3:distanceTo03};
    let sum =distanceTo03+distanceTo02+distanceTo01;
    console.log(sum);

}
tripLength([-1, -2, 3.5, 0, 0, 2]);