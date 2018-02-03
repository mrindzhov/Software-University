function getStoreCatalogue(arrayOfStrings) {
  let catalogue = new Map
  let upperCaseLetters = new Set
  for (const string of arrayOfStrings) {
    let [product, price] = string.split(' : ')
    catalogue.set(product, price)
    let firstLetter = product[0].toUpperCase()
    upperCaseLetters.add(firstLetter)
  }
  let sortedLetters = Array.from(upperCaseLetters.values()).sort()
  for (let letter of sortedLetters) {
    console.log(letter);
    for (const key of [...catalogue.keys()].sort()) {
      if (key[0].toUpperCase() === letter) {
        console.log(`  ${key}: ${catalogue.get(key)}`);
      }
    }
  }
}

let arrayOfStrings = [
  'Appricot : 20.4',
  'Fridge : 1500',
  'TV : 1499',
  'Deodorant : 10',
  'Boiler : 300',
  'Apple : 1.25',
  'Anti-Bug Spray : 15',
  'T-Shirt : 10'
]
getStoreCatalogue(arrayOfStrings)

function getLowestPriceInCities(arrayOfStrings) {
  let obj = extractData(arrayOfStrings)

  let result = ''
  for (const [product, values] of obj) {
    let selection = [...values].sort(sortAscending())[0]
    let town = selection[0]
    let price = selection[1]
    result += `${product} -> ${price} (${town})\n`
  }
  console.log(result.trim());

  function sortAscending(a, b) {
    return (a, b) => a[1] - b[1]
  }

  function extractData(strings) {
    let obj = new Map

    for (const string of arrayOfStrings) {
      let [town, product, price] = string.split(' | ')

      if (!obj.get(product)) {
        obj.set(product, new Map())
      }

      obj.get(product).set(town, Number(price))
    }
    return obj
  }
}
let arr = [
  'London | Potato | 12.31234',
  'Berlin | Potato | 31.23123',
  'Moscow | Potato | 1.23231',
  'Paris | Potato | 21.312333',
  'Pleven | Potato | 1.20',
]
// getLowestPriceInCities(arr)
