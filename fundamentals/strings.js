
function encrypt(arr) {

  let patterns = {
    namePattern: /(\*[A-Z][A-Za-z]*)(?= |\t|$)/g,
    phonePattern: /(\+[0-9-]{10})(?= |\t|$)/g,
    idPattern: /(![A-Za-z0-9]+)(?= |\t|$)/g,
    basePattern: /(_[A-Za-z0-9]+)(?= |\t|$)/g
  }
  let output = ''
  for (let str of arr) {
    for (let pattern of Object.values(patterns)) {
      let match
      while (match = pattern.exec(str)) {
        str = str.replace(match[0], '|'.repeat(match[0].length))

      }
    }
    output += str + '\n'
  }
  return output
}

let arr = [
  '(_SecretBase) or (_SecretBase   ) or (_SikretBase ) or (_SacredBase',
  'Agent *Ivankov was in the room when it all *Ivankov  happened.',
  'The person in the room was heavily armed.',
  'Agent *Ivankov had to act quick in order.',
  'He picked up his phone and called some unknown number. ',
  'I think it was +555-49-796',
  'I can\'t really remember...',
  'He said something about "finishing work" with subject !2491a23BVB34Q and returning to Base _Aurora21',
  'Then after that he disappeared from my sight.',
  'As if he vanished in the shadows.',
  'A moment, shorter than a second, later, I saw the person flying off the top floor.',
  'I really don\t know what happened there.',
  'This is all I saw, that night.',
  'I cannot explain it myself...'
]

let result = encrypt(arr)

console.log(result);

function test(input) {
  let regex = /(\*[A-Z][A-Za-z]*)(?= |\t|$)|(\+[0-9-]{10})(?= |\t|$)|(![A-Za-z0-9]+)(?= |\t|$)|(_[A-Za-z0-9]+)(?= |\t|$)/g
  
  return input
    .forEach(l => console.log(l
      .replace(
      regex,
      (m) => '|'.repeat(m.length))));
}