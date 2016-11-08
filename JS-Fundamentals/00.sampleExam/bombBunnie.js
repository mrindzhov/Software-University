function bunnyKill(arr) {

    let coordinates = arr.pop().split(" ");
    let matrix = [];
    for (let row = 0; row < arr.length; row++) {
        matrix[row] = arr[row].split(" ");
    }
    let snowBallDmg = 0;
    for (let row = 0; row < coordinates.length; row++) {
        let currentCord = coordinates[row].split(',');

        console.log(bombRow + '->' + bombColumn);
        function bombBunnies(matrix) {
            let bombRow = Number(currentCord[0]);
            let bombColumn = Number(currentCord[1]);

        }

        for (let col = 0; col < matrix.length; col++) {

            snowBallDmg = Number(matrix[row][col]);
        }
    }

    console.log(snowBallDmg);

    function bombBunnies(matrix) {


    }

    // console.log(matrix.join('\n'));
}
bunnyKill(['5 10 15 20',
        '10 10 10 10',
        '10 15 10 10',
        '10 10 10 10',
        '2,2 0,1',
]);