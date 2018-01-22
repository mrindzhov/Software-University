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