let brekfastRobot = (() => {
    let obj = {
        carbohydrate: 0,
        fat:0,
        flavour:0,
        protein:0
    };

    let operations = {
        apple: {carbs: 1, flavours: 2, fats: 0, proteins: 0},
        coke: {carbs: 10, flavours: 20, fats: 0, proteins: 0},
        burger: {carbs: 5, fats: 7, flavours: 3, proteins: 0},
        omelet: {proteins: 5, fats: 1, flavours: 1, carbs: 0},
        cheverme: {proteins: 10, carbs: 10, fats: 10, flavours: 10}
    };



    function restock (a, quantity) {
        obj[a] += Number(quantity);
        return 'Success'
    }

   function prepare (a, quntity) {
        if (obj.protein - operations[a].proteins * quntity < 0) {
            return "Error: not enough protein in stock";
        }else if (obj.carbohydrate - operations[a].carbs * quntity < 0) {
            return "Error: not enough carbohydrate in stock";
        }else if (obj.fat - operations[a].fats * quntity < 0) {
            return "Error: not enough fat in stock";
        } else if (obj.flavour - operations[a].flavours * quntity < 0) {
            return "Error: not enough flavour in stock";
        }

        obj.protein = Math.max(obj.protein - operations[a].proteins * quntity, 0);

        obj.carbohydrate = Math.max(obj.carbohydrate - operations[a].carbs * quntity, 0);

        obj.fat = Math.max(obj.fat - operations[a].fats * quntity, 0);

        obj.flavour = Math.max(obj.flavour - operations[a].flavours * quntity, 0);

        return "Success";
    }

    function report (){
        return `protein=${obj.protein} carbohydrate=${obj.carbohydrate} fat=${obj.fat} flavour=${obj.flavour}`
    }

    return function commandProcessor(input) {
        let tokens = input.split(/ /);
        let commandName = tokens.shift();
        let args = tokens;
        switch (commandName) {
            case 'prepare':
                return prepare(...args);
                break;
            case 'restock':
                return restock(...args);
                break;
            default:
                return report();
                break;
        }
    }
})();
console.log(brekfastRobot('prepare cheverme 1'));
console.log(brekfastRobot('restock protein 10'));
console.log(brekfastRobot('prepare cheverme 1'));
console.log(brekfastRobot('restock carbohydrate 10'));
console.log(brekfastRobot('prepare cheverme 1'));
console.log(brekfastRobot('restock fat 10'));
console.log(brekfastRobot('prepare cheverme 1'));
console.log(brekfastRobot('restock flavour 10'));
console.log(brekfastRobot('prepare cheverme 1'));
console.log(brekfastRobot('report'));