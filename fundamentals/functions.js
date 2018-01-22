function cookingByNums(arr) {
  let number = arr[0]
  let operations = {
    chop: (num) => num / 2,
    dice: (num) => Math.sqrt(num),
    spice: (num) => ++num,
    bake: (num) => num * 3,
    fillet: (num) => num -= num * 0.2
  }

  for (let idx = 1; idx < arr.length; idx++) {
    const currentOperation = arr[idx];
    try {
      number = operations[currentOperation](number)
      console.log(number)
    } catch (error) {
      console.log('Invalid operation');
    }
  }
}
let arr = [9, 'dice', 'spice', 'chop', 'bake', 'fillet']
cookingByNums(arr)

function modifyAverage(num) {
  let numStr = String(num)
  let getAverage = (numString) => {
    let sum = 0;
    for (let index = 0; index < numString.length; index++) {
      const element = Number(numString[index])
      sum += element
    }
    return sum / numString.length
  }

  while (getAverage(numStr) <= 5) {
    numStr += '9'
  }
  console.log(numStr);
}
let number = 101
modifyAverage(number)

function shapeCrystals(arr) {
  let targetSize = arr[0]

  let cut = (num) => num / 4
  let lap = (num) => num * 0.8
  let grind = (num) => num - 20
  let etch = (num) => num - 2
  let transportAndWash = (num) => {
    console.log(`Transporting and washing`);
    return Math.floor(num)
  }
  let xray = (num) => {
    console.log(`X-ray x1`)
    return ++num
  }
  for (let idx = 1; idx < arr.length; idx++) {
    let microns = arr[idx];
    console.log(`Processing chunk ${microns} microns`);
    microns = executeOperation(targetSize, microns, 'Cut', cut)
    microns = executeOperation(targetSize, microns, 'Lap', lap)
    microns = executeOperation(targetSize, microns, 'Grind', grind)
    microns = executeOperation(targetSize, microns, 'Etch', etch)

    if (microns + 1 == targetSize) {
      microns = xray(microns)
    }
    console.log(`Finished crystal ${microns} microns`);
  }

  function executeOperation(targetSize, size, operationName, operation) {
    let counter = 0
    while (operation(size) >= targetSize || size - targetSize === 1) {
      size = operation(size)
      counter++
    }
    if (counter > 0) {
      console.log(`${operationName} x${counter}`);
      size = transportAndWash(size)
    }

    return size
  }
}
let crystals = [1000, 4000, 8100]
shapeCrystals(crystals)

function printDna(n) {
  let structure = 'ATCGTTAGGG'
  let max = 10
  let sIndex = -1
  for (let i = 1; i <= n; i++) {
    let char1 = structure.charAt(getIndex())
    let char2 = structure.charAt(getIndex())
    if (i % 4 === 1) {
      console.log(`**${char1}${char2}**`)
    } else if (i % 4 === 2 || i % 4 === 0) {
      console.log(`*${char1}--${char2}*`)
    } else {
      console.log(`${char1}----${char2}`)
    }
  }

  function getIndex() {
    sIndex += 1
    if (sIndex === max) {
      sIndex = 0
    }

    return sIndex
  }
}
printDna(5)

function distanceIsValid(nums) {
  let x0 = 0
  let y0 = 0
  let [x1, y1, x2, y2] = nums
  let firstDistance = calcDistance(x1, y1, x0, y0)
  let secondDistance = calcDistance(x2, y2, x0, y0)
  let thirdDistance = calcDistance(x1, y1, x2, y2)

  console.log(`\{${x1}, ${y1}\} to {0, 0} is ${firstDistance % 1 !== 0 ? 'invalid' : 'valid'}`)
  console.log(`\{${x2}, ${y2}\} to {0, 0} is ${secondDistance % 1 !== 0 ? 'invalid' : 'valid'}`)
  console.log(`\{${x1}, ${y1}\} to \{${x2}, ${y2}\} is ${thirdDistance % 1 !== 0 ? 'invalid' : 'valid'}`)

  function calcDistance(x1, y1, x2, y2) {
    let deltaX = Math.abs(x1 - x2)
    let deltaY = Math.abs(y1 - y2)

    return Math.sqrt(deltaX * deltaX + deltaY * deltaY)
  }
}
distanceIsValid([2, 1, 1, 1])

function locate(arr) {
  for (let i = 0; i < arr.length - 1; i += 2) {
    let inTuvalu = isInside(arr[i], arr[i + 1], 1, 3, 1, 3)
    let inTokelau = isInside(arr[i], arr[i + 1], 8, 9, 0, 1)
    let inSamoa = isInside(arr[i], arr[i + 1], 5, 7, 3, 6)
    let inTonga = isInside(arr[i], arr[i + 1], 0, 2, 6, 8)
    let inCook = isInside(arr[i], arr[i + 1], 4, 9, 7, 8)

    if (inTuvalu) {
      console.log('Tuvalu')
    } else if (inTokelau) {
      console.log('Tokelau')
    } else if (inSamoa) {
      console.log('Samoa')
    } else if (inTonga) {
      console.log('Tonga')
    } else if (inCook) {
      console.log('Cook')
    } else {
      console.log('On the bottom of the ocean')
    }
  }

  function isInside(x1, y1, x2, x3, y2, y3) {
    if (x1 >= x2 && x1 <= x3) {
      if (y1 >= y2 && y1 <= y3) {
        return true
      }
    }

    return false
  }
}
locate([4, 2, 1.5, 6.5, 1, 3])
