function xRemoval(input) {

    let matrix = input.map(row => row.split(''));
    let checkMatrix = input.map(row => row.toLowerCase().split(''));

    for (let row = 0; row < checkMatrix.length - 2; row++) {
        for (let col = 0; col < checkMatrix[row].length - 2; col++) {
            let element = checkMatrix[row][col];
            if (checkMatrix[row][col + 2] == element &&
                checkMatrix[row + 1][col + 1] == element &&
                checkMatrix[row + 2][col + 2] == element &&
                checkMatrix[row + 2][col] == element) {

                matrix[row][col] = '';
                matrix[row][col + 2] = '';
                matrix[row + 1][col + 1] = '';
                matrix[row + 2][col] = '';
                matrix[row + 2][col + 2] = '';
            }
        }
    }
    for (let line of matrix) {
        console.log(line.join(''));
    }
}
let arr=['puoUdai', 'miU', 'ausupirina', '8n8i8', 'm8o8a', '8l8o860', 'M8i8', '8e8!8?!'];
let input=['^u^', 'j^l^a', '^w^WoWl', 'adw1w6', '(WdWoWgPoop)'];
xRemoval(arr);