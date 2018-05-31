function solve(input) {
    let catalogue = new Map;
    for (let line of input) {
        line = line.split('-');
        let [person,blogger]=[line[0], line[1]];
        if (blogger != undefined) {
            if (!catalogue.has(blogger)) {
                catalogue.set(blogger, []);
            }
            catalogue.get(blogger).push({blogger: blogger, subscriber: person});
        }
    }
    let sortedCategories = [...catalogue.keys()].sort();
    for (let category of sortedCategories) {
        console.log(category);
        let products = catalogue.get(category);
        let i = 0;
        products.forEach(p => console.log(`${++i}. ${p.subscriber}`));
    }
}
let input = ['A', 'B', 'C', 'D', 'A-B', 'B-A', 'C-A', 'D-A'];
let input2=["J","G","P","R","C","J-G","G-J","P-R","R-P","C-J"];
solve(input2);
