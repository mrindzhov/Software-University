function townsToJSON(towns) {
    let townsArr = [];
    for (let town of towns.slice(1)) {
        let [empty, townName, lat, lng] =
            town.split(/\s*\|\s*/);
        let townObj = { Town: townName, Latitude:
            Number(lat), Longitude: Number(lng) };
        townsArr.push(townObj);
    }
    return JSON.stringify(townsArr);
}

// console.log(
//     townsToJSON([
//             '| Town | Latitude | Longitude |',
//             '| Sofia | 42.696552 | 23.32601 |',
//             '| Beijing | 39.913818 | 116.363625 |']));
function scoreToHTMLTable([scoreJSON]) {
    let html = "<table>\n";
    html += "  <tr><th>name</th><th>score</th></tr>\n";
    let arr = JSON.parse(scoreJSON);
    for (let obj of arr)
        html += `  <tr><td>${htmlEscape(obj['name'])}` +
            `</td><td>${obj['score']}</td></tr>\n`;
    console.log(html + "</table>");
    function htmlEscape(text) {
        let map = { '"': '&quot;', '&': '&amp;',
            "'": '&#39;', '<': '&lt;', '>': '&gt;' };
        return text.replace(/[\"&'<>]/g, ch => map[ch]);
    }

}
// scoreToHTMLTable(['[{"name":"Pesho","score":70}]']);
function JSONToHTMLTable([json]) {
    function htmlEscape(text) {
        if(typeof text === 'string'){
            return text
                .replace(/&/g, '&amp;')
                .replace(/>/g, '&gt;')
                .replace(/</g, '&lt;')
                .replace(/"/g, '&quot;')
                .replace(/'/g, '&#39;');
        }
        else{
            return text;
        }
    }
    let html = "<table>\n";
    let arr = JSON.parse(json);
    // console.log(arr);
    html += "\t<tr>";
    for (let key of Object.keys(arr[0])) {
        html += `<th>${htmlEscape(key)}</th>`;
    }
    html += "</tr>";

    for (let obj of arr) {
        html += `\n\t<tr>`;
        for (let key of Object.keys(obj)) {

            html += `<td>${htmlEscape(obj[key])}</td>`;
        }
        html += `</tr>`;
        // console.log(obj);
        // html+=`\t<tr><td>${obj[key]}</td><td>${obj[value]}</td></tr>`
    }

    html += `\n</table>`;
    console.log(html);

}
function json2Table(input) {
    function htmlEscape(text) {
        text = '' + text;
        let tokensToReplace = {'<': '&lt;', '>': '&gt;', '&': '&amp;', '\'': '&#39;', '"': '&quot;'};
        return text.replace(/[<>&'"]/g, m => tokensToReplace[m]);
    }

    let data = JSON.parse(input);
    let htmlOutput = '<table>\n';
    htmlOutput += '  <tr>';
    for (let heading of Object.keys(data[0])) {
        htmlOutput += `<th>${heading}</th>`
    }
    htmlOutput += '</tr>\n';

    for (let item of data) {
        htmlOutput += '  <tr>';
        for (let value of Object.keys(item)) {
            htmlOutput += `<td>${htmlEscape(item[value])}</td>`;
        }
        htmlOutput += '</tr>\n';
    }

    htmlOutput += '</table>';

    return htmlOutput;
}

// json2Table(['[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]']);

function sumOfTowns(arr) {
    let totalIncome = {};
    for (let i = 0; i < arr.length; i += 2) {
        let [town, income] = arr.slice(i, i + 2);

        if (!totalIncome.hasOwnProperty(town)) {
            totalIncome[town] = 0;
        }
        totalIncome[town] += Number(income);
    }
    return JSON.stringify(totalIncome);
}
// console.log(sumOfTowns(["Sofia", "20", "Varna", "3", "Sofia", "5", "Varna", "4"]));

function countWords([arr]) {
    let wordsCount={};
    let regex=/[a-zA-Z0-9_]+/g;
    let words=arr.match(regex);
    for(let word of words){
        if(!wordsCount.hasOwnProperty(word)){
            wordsCount[word]=0;
        }
        wordsCount[word]++;
    }
    return JSON.stringify(wordsCount);
}
// console.log(countWords(['JS devs use Node.js for server-side JS.-- JS for devs']));
function countWordsWithMaps([text]) {
    let wordsCount = new Map;
    let words = text.match(/[A-Za-z0-9_]+/g);
    for (let word of words) {
        let lowerCasedWord = word.toLowerCase();
        if (!wordsCount.has(lowerCasedWord))
            wordsCount.set(lowerCasedWord, 0);
        wordsCount.set(lowerCasedWord, wordsCount.get(lowerCasedWord) + 1);
    }

    let keys = [...wordsCount.keys()].sort();

    return keys.map(k => `'${k}' -> ${wordsCount.get(k)} times`).join('\n');
}
console.log(countWordsWithMaps(['JS devs use Node.js for server-side JS. JS devs use JS. -- JS for devs --']));


function findLowestPricedProducts(input) {
    let products = new Map;
    for (let priceList of input) {
        let [town, product, price] = priceList.split(/\s+\|\s+/g);
        if (!products.has(product))
            products.set(product, new Map);
        products.get(product).set(town, Number(price));
    }

    for (let [product, towns] of products) {
        let minPrice = Number.MAX_VALUE;
        let minPriceTown = '';
        for (let [town, price] of towns) {
            if (price < minPrice) {
                minPrice = price;
                minPriceTown = town;
            }
        }

        console.log(`${product} -> ${minPrice} (${minPriceTown})`);
    }
}

