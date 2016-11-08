function arrayPlusDelimiter(arr) {
    let delimiter = arr[arr.length - 1];
    arr.pop();
    let result="";
    for (let i = 0; i < arr.length; i++) {
        if (i == 0) {
            result += arr[i];
        }
        else {
            result += delimiter + arr[i];
        }
    }
    console.log(result);
}
// arrayPlusDelimiter(['One', 'Two', 'Three', 'Four', 'Five','-']);

function printNElement(arr) {
    let step = Number(arr[arr.length - 1]);
    arr.pop();
    for (let i = 0; i < arr.length; i+=step) {
        console.log(arr[i]);
    }
}
// printNElement([5,20, 31, 4, 20, 2]);

function addRemoveElements(arr) {
    let number = 1;
    let result = [];

    for (let i = 0; i < arr.length; i++) {
        if (arr[i] == 'add') {
            result.push(number);
        }
        else if (arr[i] == 'remove'){
            result.pop();
        }
        number++;
    }
    if(result.length>0) {
        console.log(result.join('\n'));
    }
    else{
        console.log('Empty');
    }
}
// addRemoveElements(['add', 'add', 'remove', 'add', 'add']);

function rotateArray(arr) {
    let rotations = Number(arr[arr.length - 1]);
    arr.pop();
    for (let i = 0; i < rotations % arr.length; i++) {
        arr.unshift(arr.pop());
    }
    console.log(arr.join(' '));
}
// rotateArray(['Banana', 'Orange', 'Coconut', 'Apple',15]);

function extractIncreasingSubsequence (arr) {
    let biggestNum=Number(arr[0]);
    for (let i = 0; i < arr.length; i++) {
        if(arr[i]>=biggestNum){
            console.log(arr[i]);
        }
        biggestNum=Number(arr[i]);
    }
}
// extractIncreasingSubsequence([1,3,8, 4, 10, 12, 3, 2, 24]);

function sortArray(arr) {
    console.log(arr.sort((a,b)=>a.localeCompare(b))
        .sort((a,b)=>a.length-b.length)
        .join('\n'));
}
// sortArray(['test', 'Deny', 'omen', 'Default']);

function magicMatrix(arr) {
    let matrix = arr.map(
        row => row.split(' ').map(Number));

    function isMagic(matrix) {
        let sum = [];
        let sumCol = 0, sumRow = 0;
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix.length; col++) {
                sumRow += Number(matrix[row][col]);
                sumCol += Number(matrix[col][row]);
            }
            sum.push(sumRow);sum.push(sumCol);
            sumCol = 0;sumRow = 0;
            for (let i = 0; i < sum.length - 1; i++) {
                if (sum[i] != sum[i + 1])
                    return false;
            }
        }
        return true;
    }
    console.log(isMagic(matrix));
}
// magicMatrix(['11 32 45','21 0 1','21 1 1']);

function spiralMatrix(arr) {
    let rows = Number(arr[0]);
    let cols = Number(arr[1]);

    let matrix = [];

    function fillMatrix(matrix) {
        let counter=1;
        for (var i = 0; i < rows; i++) {
            matrix[i] = [];
            for (var j = 0; j < cols; j++) {
                matrix[i][j] = counter;
                counter++;
            }
        }
    }
    function printMatrix(matrix) {

        for (let i = 0; i < matrix.length; i++) {
            console.log(matrix[i].join(' '));
        }
    }



    fillMatrix(matrix);
    printMatrix(matrix);

}
// spiralMatrix(['5','5']);

function orbit(arr){

    let dimensions = arr[0];
    let rows = Number(dimensions[0]);
    let cols= Number(dimensions[0]);
    
    let targetCells = arr[0];
    let rowsTarget = Number(targetCells[0]);
    let colsTarget= Number(targetCells[0]);

    let matrix = [];
    function fillMatrix(matrix) {
        let counter=1;
        for (var i = 0; i < rows; i++) {
            matrix[i] = [];
            for (var j = 0; j < cols; j++) {
                matrix[i][j] = counter;
                counter++;
            }
        }
    }


    function printMatrix(matrix) {

        for (let i = 0; i < matrix.length; i++) {
            console.log(matrix[i].join(' '));
        }
    }

    fillMatrix(matrix);
    printMatrix(matrix);
}
orbit(['5 5','2 2']);