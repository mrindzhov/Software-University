function sumFirstLast(arr) {
    return Number(arr[0]) + Number(arr[arr.length - 1]);
}
// sumFirstLast(['20', '30', '40']);

function evenPosEl(arr) {
    let result=[];
    for(let i in arr){
        if(i%2==0){
            result.push(arr[i]);
        }
    }
    return result.join(' ');
}
// evenPosEl(['20', '30', '40']);

function negPosNumb(arr) {
    arr = arr.map(Number);
    let result = [];

    for (num of arr) {
        if (num <0) {
            result.unshift(num);
        }
        else {
            result.push(num);
        }
    }
    console.log(result.join(' '));
}
// negPosNumb(['7', '-2', '8', '9']);

function firstAndLastKNums(arr) {
    let k = Number(arr.shift());
    console.log(arr.slice(0,k).join(' '));
    console.log(arr.slice(arr.length-k,arr.length).join(' '));
}
// firstAndLastKNums(['2', '7', '8', '9']);

function sumLastKNumbersSequence([n, k]) {
    let seq = [1];
    for (let current = 1; current < n; current++) {
        let start = Math.max(0, current - k);
        let end = current - 1;
        let sum = // TODO: sum the values of seq[start … end]
            seq[current] = sum;
    }
    console.log(seq.join(' '));
}
sumLastKNumbersSequence([6,3]);

lasKNumberSeq(['6', '3']);
function equalNeighborsCount(matrixRows) {
    let matrix = matrixRows.map(
        row => row.split(' ').map(Number));
    let neighbors = 0;
    for (let row = 0; row < matrix.length-2; row++)
        for (let col = 0; col < matrix[row].length; col++)
            if (matrix[row][col] == matrix[row + 1][col])
                neighbors++;
    for (let row = 0; row < matrix.length-2; row++)
        for (let col = 0; col < matrix[row].length; col++)
            if (matrix[row][col] == matrix[row][col+1])
                neighbors++;
    return neighbors;
}