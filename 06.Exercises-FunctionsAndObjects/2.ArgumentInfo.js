function argumentInfo(input) {
    let map = new Map();
    for (let i = 0; i < arguments.length; i++) {
        let obj = arguments[i];
        let type = typeof obj;
        console.log(type + ': ' + obj);
        if(!map[type]){
            map[type] = 1;
        }else{
            map[type]++;
        }
    }

    let sorted = [];

    for (let currentType in map) {
        sorted.push([currentType, map[currentType]]);
    }

    sorted.sort(function(a, b) {
        a = a[1];
        b = b[1];

        return b - a;
    });

    for (let element of sorted) {
        console.log(element[0] + ' = ' + element[1]);
    }
}