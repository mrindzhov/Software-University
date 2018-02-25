function spyMaster(arr) {

  let specialKey = arr[0];
  let keyRegex = /[A-Za-z]+/;

  if (keyRegex.test(specialKey)) {

    let regex = new RegExp(`\\b(${specialKey})\\s+([A-Z!%$#]{8,})(?=[ .,]|$)`, 'gmi');

    for (let i = 1; i < 3; i++) {

      let string = arr[i];

      let match = regex.exec(string);

      while (match !== null) {

        if (!/[a-z]/.test(match[2])) {

          let text = match[2];
          let textForShanoPUrposes = text

          text = text.replace(/!/gm, '1')
            .replace(/%/gm, '2')
            .replace(/#/gm, '3')
            .replace(/\$/gm, '4');
          text = text.toLowerCase();
          console.log(match["index"]);
          console.log(match);
          let substringed = string
            .substring(match['index'] - 3 ? match['index'] - 3 : match['index'], match['index'] + match[0].length)
          console.log(substringed);
          string = string.replace(match[2], text);
          console.log(string.replaceAt9(substringed, text));
        }
        match = regex.exec(string);
      }

      // console.log(string) 
    }
  }

}
let input = [
  'tricky',
  'And now the tricky tests',
  'Tricky CAREFULL!#$%; with what you decode Tricky CAREFULL!#$%',
  'Tricky HERECOMESDASH- with what you decode Tricky HERECOMESDASH -',
  'Try again stricky NOTTHEFIRSTONE  tricky NOTTHEFIRSTONE',
  'Be very carefull now trICkY plainwrong, trICkY PLAINWRONG',
  'next challenge (tRickY SOME$WORDS) tRickY SOME$WORDS',
  'It\'s tricky TOUSETHECORRECTREPLACE? tricky TOUSETHECORRECTREPLACE ,',
  'now with commas triCky RAND!$OM%$#TE!#XT, triCky RAND!$OM%$#TE!#XT.',
  'DON\'T match this plz TRICKY | TEXT#TEXT. TRICKY  TEXT#TEXT.',
  'Try with commas -triCkY COMMAHERE, triCkY COMMAHERE, wow',
]
spyMaster(input)