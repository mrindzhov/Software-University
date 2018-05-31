function sortBy(arr, criterion) {
    let criteria = {
        'asc': (a, b) => a - b, //ascending
        'desc': (a, b) => b - a //descending
    };

    return arr.sort(criteria[criterion]);
}

function getArgumentsInfo() {
    let typesCount = new Map;

    for (let arg of arguments) {
        let type = typeof arg;
        if (!typesCount.has(type)) {
            typesCount.set(type, 0);
        }

        let oldValue = typesCount.get(type);
        typesCount.set(type, oldValue + 1);
        console.log(`${type}: ${arg}`);
    }

    let asd = [...typesCount].sort((a, b) => b[1] - a[1])
    asd.forEach(entry => console.log(`${entry[0]} = ${entry[1]}`))
}

console.log((function () {
    let sum = 0;

    function add(number) {
        sum += number;
        return add
    }

    add.toString = function () {
        return sum
    };

    return add
})()(15)(5)+'');

function getPersonalBmi(name, age, weight, height) {
    function getStatus() {
        if (bmi < 18.5) {
            return 'underweight';
        } else if (bmi < 25) {
            return 'normal';
        } else if (bmi < 30) {
            return 'overweight';
        } else {
            return 'obese';
        }
    }

    let heightInMeters = height / 100;
    let bmi = weight / Math.pow(heightInMeters, 2);
    let evaluation = {
        name: name,
        personalInfo: {
            age: Math.round(age),
            weight: Math.round(weight),
            height: Math.round(height)
        },
        BMI: Math.round(bmi),
        status: getStatus()
    };

    if (status === 'obese') {
        evaluation.recommendation = 'admission required';
    }

    return evaluation;
}

(function () {
        return {
            add: (vector1, vector2) => [vector1[0] + vector2[0], vector1[1] + vector2[1]],
            multiply: (vector1, scalar) => [vector1[0] * scalar, vector1[1] * scalar],
            length: (vector) => Math.sqrt(vector[0] * vector[0] + vector[1] * vector[1]),
            dot: (vector1, vector2) => vector1[0] * vector2[0] + vector1[1] * vector2[1],
            cross: (vector1, vector2) => vector1[0] * vector2[1] - vector1[1] * vector2[0]
        }
    }
)();

let robot = (function breakfastRobot() {
    let ingredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    let commands = {
        prepare: {
            "apple": () => {
                if (ingredients.carbohydrate < 1) {
                    return 'Error: not enough carbohydrate in stock'
                } else if (ingredients.flavour < 2) {
                    return 'Error: not enough flavour in stock'
                } else {
                    ingredients.carbohydrate -= 1;
                    ingredients.flavour -= 2;
                    return 'Success'
                }
            },
            "coke": () => {
                if (ingredients.carbohydrate < 10) {
                    return 'Error: not enough carbohydrate in stock'
                } else if (ingredients.flavour < 20) {
                    return 'Error: not enough flavour in stock'
                } else {
                    ingredients.carbohydrate -= 10;
                    ingredients.flavour -= 20;
                    return 'Success';
                }
            },
            "burger": () => {
                if (ingredients.carbohydrate < 5) {
                    return 'Error: not enough carbohydrate in stock'
                } else if (ingredients.fat < 7) {
                    return 'Error: not enough fat in stock'
                } else if (ingredients.flavour < 3) {
                    return 'Error: not enough flavour in stock'
                } else {
                    ingredients.carbohydrate -= 5;
                    ingredients.fat -= 7;
                    ingredients.flavour -= 3;
                    return 'Success';
                }
            },
            "omelet": () => {
                if (ingredients.protein < 5) {
                    return 'Error: not enough protein in stock'
                } else if (ingredients.fat < 1) {
                    return 'Error: not enough fat in stock'
                } else if (ingredients.flavour < 1) {
                    return 'Error: not enough flavour in stock'
                } else {
                    ingredients.protein -= 5;
                    ingredients.fat -= 1;
                    ingredients.flavour -= 1;
                    return 'Success';
                }
            },
            "cheverme": () => {
                if (ingredients.protein < 10) {
                    return 'Error: not enough protein in stock'
                } else if (ingredients.carbohydrate < 10) {
                    return 'Error: not enough carbohydrate in stock'
                } else if (ingredients.fat < 10) {
                    return 'Error: not enough fat in stock'
                } else if (ingredients.flavour < 10) {
                    return 'Error: not enough flavour in stock'
                } else {
                    ingredients.protein -= 10;
                    ingredients.carbohydrate -= 10;
                    ingredients.fat -= 10;
                    ingredients.flavour -= 10;
                    return 'Success';
                }
            }
        },
        restock: ([ingredient, quantity]) => {
            quantity = Number(quantity);
            ingredients[ingredient] += quantity;
            return "Success";
        },
        report: () => `protein=${ingredients.protein} carbohydrate=${ingredients.carbohydrate} fat=${ingredients.fat} flavour=${ingredients.flavour}`
    };

    return (instructions) => {
        let tokens = instructions.split(' ');
        let command = tokens.shift();
        if (command !== 'prepare') {
            return commands[command](tokens)
        } else {
            let meal = tokens[0];
            let quantity = Number(tokens[1]);
            let message;
            for (let i = 0; i < quantity; i++) {
                message = commands[command][meal]();
                if (message !== 'Success') {
                    break;
                }
            }
            return message;
        }
    }
})();
// console.log(robot('restock flavour 50'));
// console.log(robot('prepare coke 2'));
//
// let expectationPairs = [
//     ['restock carbohydrate 10', 'Success'],
//     ['restock flavour 10', 'Success'],
//     ['prepare apple 1', 'Success'],
//     ['restock fat 10', 'Success'],
//     ['prepare burger 1', 'Success'],
//     ['report', 'protein=0 carbohydrate=4 fat=3 flavour=5']
// ];

// for (let i = 0; i < expectationPairs.length; i++) {
//     let expectation = expectationPairs[i];
//     console.log(robot(expectation[0]));
// }
function prepareBreakfast() {
    let ingredients = {
        protein: 0, carbohydrate: 0, fat: 0, flavour: 0
    };
    let meals = {
        apple: {protein: 0, carbohydrate: 1, fat: 0, flavour: 2},
        coke: {protein: 0, carbohydrate: 10, fat: 0, flavour: 20},
        burger: {protein: 0, carbohydrate: 5, fat: 7, flavour: 3},
        omelet: {protein: 5, carbohydrate: 0, fat: 1, flavour: 1},
        cheverme: {protein: 10, carbohydrate: 10, fat: 10, flavour: 10}
    };
    let commands = {
        restock: (product, quantity) => {
            ingredients[product] += Number(quantity);
            return 'Success'
        },
        prepare: (meal, quantity) => {
            try {
                validateIngredientsQuantity();
                masteChefInTheHouse()
                return 'Success'
            } catch (e) {
                return e.message;
            }

            function masteChefInTheHouse() {
                ingredients.protein -= meals[meal].protein * quantity
                ingredients.carbohydrate -= meals[meal].carbohydrate * quantity
                ingredients.fat -= meals[meal].fat * quantity
                ingredients.flavour -= meals[meal].flavour * quantity
            }

            function validateIngredientsQuantity() {
                if (meals[meal].protein * quantity > ingredients.protein) {
                    throw new Error(`Error: not enough protein in stock`)
                } else if (meals[meal].carbohydrate * quantity > ingredients.carbohydrate) {
                    throw new Error(`Error: not enough carbohydrate in stock`)
                } else if (meals[meal].fat * quantity > ingredients.fat) {
                    throw new Error(`Error: not enough fat in stock`)
                } else if (meals[meal].flavour * quantity > ingredients.flavour) {
                    throw new Error(`Error: not enough flavour in stock`)
                }
            }
        },
        report: () => `protein=${ingredients.protein} carbohydrate=${ingredients.carbohydrate} fat=${ingredients.fat} flavour=${ingredients.flavour}`
    };


    return (input) => {
        input = input.split(/ /);
        return commands[input.shift()](...input);
    }
}

let brekfastRobot = (() => {
    let available = {
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
        protein: 0
    };

    let needed = {
        apple: {carbs: 1, flavours: 2, fats: 0, proteins: 0},
        coke: {carbs: 10, flavours: 20, fats: 0, proteins: 0},
        burger: {carbs: 5, fats: 7, flavours: 3, proteins: 0},
        omelet: {proteins: 5, fats: 1, flavours: 1, carbs: 0},
        cheverme: {proteins: 10, carbs: 10, fats: 10, flavours: 10}
    };

    function validateAvailability(product, quantity) {
        if (available.protein - needed[product].proteins * quantity < 0) {
            return "Error: not enough protein in stock";
        } else if (available.carbohydrate - needed[product].carbs * quantity < 0) {
            return "Error: not enough carbohydrate in stock";
        } else if (available.fat - needed[product].fats * quantity < 0) {
            return "Error: not enough fat in stock";
        } else if (available.flavour - needed[product].flavours * quantity < 0) {
            return "Error: not enough flavour in stock";
        }
    }

    let commands = {
        restock: (product, quantity) => {
            available[product] += Number(quantity);
            return 'Success'
        },
        prepare: (product, quantity) => {
            let message = validateAvailability(product, quantity);
            if (message) return message;

            available.protein = available.protein - needed[product].proteins * quantity;
            available.carbohydrate = available.carbohydrate - needed[product].carbs * quantity;
            available.fat = available.fat - needed[product].fats * quantity;
            available.flavour = available.flavour - needed[product].flavours * quantity;

            return "Success";
        },
        report: () => `protein=${available.protein} carbohydrate=${available.carbohydrate} fat=${available.fat} flavour=${available.flavour}`
    };

    return (input) => {
        let tokens = input.split(/ /);
        let commandName = tokens.shift();
        return commands[commandName](...tokens)
    }
})
();
// console.log(brekfastRobot('prepare cheverme 1'));
// console.log(brekfastRobot('restock protein 10'));
// console.log(brekfastRobot('prepare cheverme 1'));
// console.log(brekfastRobot('restock carbohydrate 10'));
// console.log(brekfastRobot('prepare cheverme 1'));
// console.log(brekfastRobot('restock fat 10'));
// console.log(brekfastRobot('prepare cheverme 1'));
// console.log(brekfastRobot('restock flavour 10'));
// console.log(brekfastRobot('prepare cheverme 1'));
// console.log(brekfastRobot('report'));

function monkeyPatch(input) {
    let self = this;
    let commands = {
        upvote: () => {
            self.upvotes++
        },
        downvote: () => {
            self.downvotes++
        },
        score: () => {
            let currentUpvotes = self.upvotes;
            let currentDownvotes = self.downvotes;
            let rating = 'new';

            let isNewPost = currentUpvotes + currentDownvotes < 10;
            if (!isNewPost) {
                updateRating();
            }

            let shouldObfuscate = currentUpvotes + currentDownvotes > 50
            if (shouldObfuscate) {
                inflateVotes();
            }
            let score = currentUpvotes - currentDownvotes;
            return [currentUpvotes, currentDownvotes, score, rating];

            function updateRating() {
                if (currentUpvotes > 0.66 * (currentUpvotes + currentDownvotes)) {
                    rating = 'hot';
                } else if (currentDownvotes > currentUpvotes) {
                    rating = 'unpopular';
                } else if (currentUpvotes > 100 || currentDownvotes > 100) {
                    rating = 'controversial';
                }
            }

            function inflateVotes() {
                let modifier = Math.ceil(0.25 * Math.max(currentUpvotes, currentDownvotes));
                currentUpvotes += modifier;
                currentDownvotes += modifier;
            }
        }
    };
    return commands[input]();
}

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};

monkeyPatch.call(post, 'upvote');
monkeyPatch.call(post, 'downvote');
let score = monkeyPatch.call(post, 'score'); // [127, 127, 0, 'controversial']
console.log(score);
for (var i = 0; i < 0; i++) {
    monkeyPatch.call(post, 'downvote');
}
score = monkeyPatch.call(post, 'score');
console.log(score);// (executed 50 times)

function euclidAlgorithm(numA, numB) {
    if (numA === 0) {
        return numB;
    }

    if (numB === 0) {
        return numA;
    }

    return solve(numB, numA % numB);
}

function solve(mean, ecc) {
    console.log(Number(approximate(mean, ecc, 0).toFixed(9)));

    function approximate(E0, ecc, series) {
        if (Math.abs(mean - (E0 - ecc * Math.sin(E0))) < 1e-9 || series > 200) return E0;
        else return approximate(E0 - (E0 - ecc * Math.sin(E0) - mean) / (1 - ecc * Math.cos(E0)), ecc, ++series);
    }
}