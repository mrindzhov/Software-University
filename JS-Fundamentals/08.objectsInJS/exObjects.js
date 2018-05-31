function heroicInventory(arr){
    let heroData=[];

    for (let i = 0; i < arr.length; i++) {
        let currentHeroArguments = arr[i].split(' / ');
        let currentHeroItems=[];
        let currentHeroName=currentHeroArguments[0];
        let currentHeroLevel=Number(currentHeroArguments[1]);
        if(currentHeroArguments.length>2) {
            currentHeroItems = currentHeroArguments[2].split(", ");
        }
        let hero={
            name: currentHeroName,
            level: currentHeroLevel,
            items: currentHeroItems
        };
        heroData.push(hero);
    }
    console.log(JSON.stringify(heroData));
}
// heroicInventory([`Isaac / 25 / Apple, GravityGun`,
//   `Derek / 12 / BarrelVest, DestructionSword`,
//   `Hes / 1 / Desolator, Sentinel, Antara]`]);
function JSONTable(arr) {

    let html="<table>\n";
    for (let i = 0; i < arr.length; i++) {
        let currentLine = JSON.parse(arr[i]);
        html+="\t<tr>\n";
        for(let element in currentLine){
            html+=`\t\t<td>${htmlEscape(currentLine[element])}</td>\n`;
        }
        html+="\t<tr>\n";
    }

    html+="</table>";
    console.log(html);
    function htmlEscape(text) {
        text = '' + text;
        let tokensToReplace = {'<': '&lt;', '>': '&gt;', '&': '&amp;', '\'': '&#39;', '"': '&quot;'};
        return text.replace(/[<>&'"]/g, m => tokensToReplace[m]);
    }
}
// JSONTable(['{"name":"Pesho","position":"Promenliva","salary":100000}',
//     '{"name":"Teo","position":"Lecturer","salary":1000}',
//     '{"name":"Georgi","position":"Lecturer","salary":1000}']);
function cappyJuice(arr) {
    let obj = {};

    for (let i = 0; i < arr.length; i++) {
        let currentLine = arr[i].split(' => ');
        let fruit = String(currentLine[0]);
        let quantity = Number(currentLine[1]);
        if (!obj.hasOwnProperty(fruit)) {
            obj[fruit] = quantity;
        } else {
            let curr=obj[fruit];
            curr+=quantity;
            obj[fruit]=curr;
        }
    }

    for(let el in obj){
        if(obj[el]>1000){
            console.log(`${el} => ${parseInt(obj[el]/1000)}`);
        }
    }
}
// cappyJuice(["Kiwi => 234","Pear => 2345",
// "Watermelon => 3456","Kiwi => 4567","Pear => 5678","Watermelon => 6789"]);
function cappyJuiceMAP(input) {
    let totalJuice = new Map;
    let totalBottles = new Map;
    for (let line of input) {
        let tokens = line.split(/\s*=>\s*/);
        let [type, quantity] = [tokens[0], Number(tokens[1])];
        if (!totalJuice.has(type)) {
            totalJuice.set(type, 0);
        }
        let currentQuantity = totalJuice.get(type);
        currentQuantity += quantity;

        if (currentQuantity >= 1000) {
            let juiceLeft = currentQuantity % 1000;
            let bottlesToStore = (currentQuantity - juiceLeft) / 1000;
            if (!totalBottles.has(type)) {
                totalBottles.set(type, 0);
            }

            totalBottles.set(type, totalBottles.get(type) + bottlesToStore);
            quantity = juiceLeft;
        }

        totalJuice.set(type, totalJuice.get(type) + quantity);
    }

    for (let [juice, bottles] of totalBottles) {
        console.log(`${juice} => ${bottles}`);
    }
}
// cappyJuiceMAP(["Kiwi => 234", "Pear => 2345",
// "Watermelon => 3456", "Kiwi => 4567", "Pear => 5678", "Watermelon => 6789"]);


storageCatalogue(["Appricot : 20.4","Fridge : 1500","TV : 1499","Deodorant : 10",
    "Boiler : 300","Apple : 1.25","Anti-Bug Spray : 15","T-Shirt : 10"]);
function storageCatalogue(data) {
    let catalogue = new Map;
    for (let line of data) {
        let tokens = line.split(/\s:\s/);
        let [product, price] = [tokens[0], Number(tokens[1])];
        let productFirstLetter = product[0].toUpperCase();
        if (!catalogue.has(productFirstLetter)) {
            catalogue.set(productFirstLetter, []);
        }

        catalogue.get(productFirstLetter).push({title: product, value: price});
    }

    function customComparator(productA, productB) {
        return productA.title.toLowerCase().localeCompare(productB.title.toLowerCase());
    }
    let sortedCategories = [...catalogue.keys()].sort();
    for (let category of sortedCategories) {
        console.log(category);
        let products = catalogue.get(category).sort(customComparator);
        products.forEach(p => console.log(`  ${p.title}: ${p.value}`));
    }
}