rotateArray = (arr) => {
  let rotations = arr.pop()
  for (let i = 0; i < rotations % arr.length; i++) {
    arr.unshift(arr.pop())
  }
  console.log(arr.join(' '))
}
const arrayForRotation = ['Banana', 'Orange', 'Coconut', 'Apple', 15];
rotateArray(arrayForRotation)

extractNonDecreasingSubsequence = (arr) => {
  let currentMax = arr[0]
  return arr.filter((value) => {
    if (value >= currentMax) {
      currentMax = value
      return true
    }
  }).join('\n')
}
const sequence = [1, 3, 8, 4, 10, 12, 3, 2, 24]
const resultSeq = extractNonDecreasingSubsequence(sequence)
console.log(resultSeq)

sortArray = (arr) => arr.sort((a, b) => a.localeCompare(b))
  .sort((a, b) => a.length - b.length)
  .join('\n')

const arrayForSorting = ['test', 'Deny', 'omen', 'Default']
const resultSort = sortArray(arrayForSorting)
console.log(resultSort)

// Multidimensional Arrays
isMatrixMagic = (matrix) => {
  let firstRowSum = matrix[0].reduce((a, b) => a + b)

  for (let row = 0; row < matrix.length; row++) {
    let sumCol = sumRow = 0;
    for (let col = 0; col < matrix.length; col++) {
      sumRow += Number(matrix[row][col]);
      sumCol += Number(matrix[col][row]);
    }
    if (sumRow != sumCol || sumCol != firstRowSum) {
      return false
    }
  }
  return true
}
const magicMatrixArray2 = [[4, 5, 6], [6, 5, 4], [5, 5, 5]]
const magicMatrixArray = [[11, 32, 45], [21, 0, 1], [21, 1, 1]]
isMatrixMagic(magicMatrixArray2)


spiralMatrix = (rows, cols) => {
  let matrix = fillZeros(rows, cols)
  fillMatrix(matrix, 0, 0, 1)
  printMatrix(matrix)

  function fillMatrix(matrix, currentRow, currentCol, counter) {
    if (matrix[currentRow][currentCol] !== 0) {
      return matrix
    }

    // fill Top Row rightwards
    for (let col = currentCol; col < rows - currentRow; col++) {
      matrix[currentRow][col] = counter++
    }

    // fill Right colum downwards
    for (let row = 1 + currentRow; row < cols - currentCol; row++) {
      matrix[row][rows - 1 - currentRow] = counter++
    }

    // fill Bottom leftwards
    for (let col = cols - 2 - currentCol; col >= currentCol; col--) {
      matrix[rows - 1 - currentRow][col] = counter++
    }

    // fill Left column upwards
    for (let row = rows - 2 - currentRow; row > currentRow; row--) {
      matrix[row][currentCol] = counter++
    }

    fillMatrix(matrix, ++currentRow, ++currentCol, counter)
  }
  function printMatrix(matrix) {
    console.log(matrix.map(el => el.join(" ")).join('\n'))
  }
  function fillZeros(rows, cols) {
    let matrix = []
    for (let i = 0; i < rows; i++) {
      matrix.push('0'.repeat(cols).split('').map(Number))
    }
    return matrix
  }
}

spiralMatrix(4, 4);

function orbit(arr) {
  let [rows, cols, targetRow, targetCol] = arr
  let matrix = fillZeros(rows, cols)

  let num = 1
  matrix[targetRow][targetCol] = num
  let waveCount = 1

  while (!isFilled(matrix)) {
    num++

    let topX = Math.max(0, targetRow - waveCount)
    let topY = Math.max(0, targetCol - waveCount)
    let bottomX = Math.min(matrix.length - 1, targetRow + waveCount)
    let bottomY = Math.min(matrix[0].length - 1, targetCol + waveCount)

    for (let row = topX; row <= bottomX; row++) {
      for (let col = topY; col <= bottomY; col++) {
        if (matrix[row][col] === 0) {
          matrix[row][col] = num
        }
      }
    }
    waveCount++
  }

  printMatrix(matrix)

  function isFilled(matrix) {
    for (let row = 0; row < matrix.length; row++) {
      for (let col = 0; col < matrix[row].length; col++) {
        if (matrix[row][col] === 0) {
          return false
        }
      }
    }

    return true
  }
  function fillZeros(rows, cols) {
    let matrix = []
    for (let i = 0; i < rows; i++) {
      matrix.push('0'.repeat(cols).split('').map(Number))
    }
    return matrix
  }
  function printMatrix(matrix) {
    console.log(matrix.map(el => el.join(" ")).join('\n'))
  }
}

function diagonalAttack(input) {
    let matrix = input.map(r => r.split(' ').map(Number))
    let [mainDiagonalSum, secondaryDiagonalSum] = getBothDiagonalsSum(matrix)
    if(mainDiagonalSum === secondaryDiagonalSum) {
        for(let row = 0; row < matrix.length; row++) {
            for(let col = 0; col < matrix[row].length; col++) {
                let temp = matrix[row][col]
                if (row !== col && col !== matrix[row].length - 1 - row) {
                    matrix[row][col] = mainDiagonalSum
                }

            }
        }
    }

    for(let row = 0; row < matrix.length; row++) {
        console.log(matrix[row].join(' '))
    }

    function getBothDiagonalsSum(matrix) {
        let mainDiagonalSum = 0
        let secondaryDiagonalSum = 0
        for(let row = 0; row < matrix.length; row++) {
            mainDiagonalSum += matrix[row][row]
            secondaryDiagonalSum += matrix[row][matrix[row].length - 1 - row]
        }

        return [mainDiagonalSum, secondaryDiagonalSum]
    }
}

diagonalAttack(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
)

diagonalAttack(['1 1 1',
    '1 1 1',
    '1 1 0']
)