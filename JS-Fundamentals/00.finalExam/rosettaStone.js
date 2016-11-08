function solve(input) {
    function defineLetter(key) {
        let alpha = ` ABCDEFGHIJKLMNOPQRSTUVWXYZ`;
        if (key == 27)
            key = 0;
        if (key > 27)
            key = key % 27;
        return alpha[key];
    }

    let n = Number(input.shift(input[0]));
    let matrix = input.map(row => row.split(' ').map(Number));
    let pattern = [];
    for (let row = 0; row < n; row++)
        pattern[row] = matrix.shift(matrix[row]).map(Number);
    let firstElement = pattern[0];
    for (let i = 0; i < matrix.length; i += (pattern.length)) {
        let row = matrix[i];
        for (let j = 0; j < row.length; j += (firstElement.length))
            for (let m = 0; m < pattern.length; m++) {
                let CubeLikePattern = pattern[m];
                for (let n = 0; n < CubeLikePattern.length; n++)
                    if (matrix[i + m] != undefined && matrix[m + i][j + n] != undefined)
                        matrix[m + i][n + j] = defineLetter(pattern[m][n] + matrix[i + m][j + n]);
            }
    }
    return matrix.toString().replace(/\,/g, '');
}
let input=[ '2',
    '59 36',
    '82 52',
    '4 18 25 19 8',
    '4 2 8 2 18',
    '23 14 22 0 22',
    '2 17 13 19 20',
    '0 9 0 22 22' ];
console.log(solve(input));


