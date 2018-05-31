function jsonTable(arr) {
	let table = '<table>\n';
	for (let line of arr) {
		let employee = JSON.parse(line);
		employee.salary = Number(employee.salary);
		table += '\t<tr>\n';
		let keys = Object.keys(employee);
		for (let key of keys)
			table += `\t\t<td>${htmlEscape(employee[key])}</td>\n`;
		table += '\t<tr>\n'; // incorrect html but satisfies problem requirements & judge
	}
	table += '</table>';
	console.log(table);

	function htmlEscape(text) {
		text = '' + text;
		return text.replace(/&/g, '&amp;')
			.replace(/</g, '&lt;')
			.replace(/>/g, '&gt;')
			.replace(/"/g, '&quot;')
			.replace(/'/g, '&#39;');
	}
}

jsonTable([
	'{"name":"Pesho","position":"Promenliva","salary":100000}',
	'{"name":"Teo","position":"Lecturer","salary":1000}',
	'{"name":"Georgi","position":"Lecturer","salary":1000}'
]);

function cappyJuice(input) {
	let juiceQuantities = new Map();
	let juiceBottles = new Map();
	for (let line of input) {
		let [juice, quantity] = line.split(/\s*=>\s*/g);
		quantity = Number(quantity);
		if (juiceQuantities.has(juice))
			quantity += juiceQuantities.get(juice);
		juiceQuantities.set(juice, quantity);
		if (quantity >= 1000)
			juiceBottles.set(juice, Math.floor(quantity / 1000));
	}
	for (let [juice, bottles] of juiceBottles)
		console.log(`${juice} => ${bottles}`);
}

cappyJuice([
	'Orange => 2000',
	'Peach => 1432',
	'Banana => 450',
	'Peach => 600',
	'Strawberry => 549'
]);

cappyJuice([
	'Kiwi => 234',
	'Pear => 2345',
	'Watermelon => 3456',
	'Kiwi => 4567',
	'Pear => 5678',
	'Watermelon => 6789'
]);

function storeCatalogue(arr) {
	let catalogue = new Map();
	for (let line of arr) {
		let [product, price] = line.split(/\s*:\s*/);
		let catalogueLetter = product.toUpperCase()[0];
		if (!catalogue.has(catalogueLetter))
			catalogue.set(catalogueLetter, new Map);
		catalogue.get(catalogueLetter).set(product, Number(price));
	}
	let keys = Array.from(catalogue.keys()).sort(); // cat. letters in alphabetical order
	for (let key of keys) {
		console.log(key);
		let products = [...catalogue.get(key).keys()].sort();
		for (let product of products)   // products in alphabetical order
			console.log(`  ${product}: ${catalogue.get(key).get(product)}`);
	}
}

storeCatalogue([
	'Appricot : 20.4',
	'Fridge : 1500',
	'TV : 1499',
	'Deodorant : 10',
	'Boiler : 300',
	'Apple : 1.25',
	'Anti-Bug Spray : 15',
	'T-Shirt : 10'
]);

storeCatalogue([
	"Banana : 2",
	"Rubic's Cube : 5",
	"Raspberry P : 4999",
	"Rolex : 100000",
	"Rollon : 10",
	"Rali Car : 2000000",
	"Pesho : 0.000001",
	"Barrel : 10"
]);

function autoEngineeringCompany(arr) {
	let carRegister = new Map; // car brand - car model - produced cars
	for (let line of arr) {
		let [brand, model, producedCars] = line.split(/\s*\|\s*/g);
		producedCars = Number(producedCars);
		if (!carRegister.get(brand))
			carRegister.set(brand, new Map);
		if (carRegister.get(brand).get(model))
			producedCars += carRegister.get(brand).get(model);
		carRegister.get(brand).set(model, producedCars);
	}
	// print in order of appearance
	for (let [brand, brandData] of carRegister) {
		console.log(brand);
		for (let [model, producedCars] of brandData)
			console.log(`###${model} -> ${producedCars}`);
	}
}

autoEngineeringCompany([
	'Audi | Q7 | 1000',
	'Audi | Q6 | 100',
	'BMW | X5 | 1000',
	'BMW | X6 | 100',
	'Citroen | C4 | 123',
	'Volga | GAZ-24 | 1000000',
	'Lada | Niva | 1000000',
	'Lada | Jigula | 1000000',
	'Citroen | C4 | 22',
	'Citroen | C5 | 10'
]);

function systemComponents(arr) {
	let systemComponents = new Map(); // system - component - subcomponent
	for (let line of arr) {
		let [system, component, subcomponent] = line.split(/\s*\|\s*/g);
		if (!systemComponents.has(system))
			systemComponents.set(system, new Map);
		if (!systemComponents.get(system).has(component))
			systemComponents.get(system).set(component, new Set); // unique subcomponents
		systemComponents.get(system).get(component).add(subcomponent);
	}
	// sort systems
	let systemsSorted = [...systemComponents.keys()].sort(function (a, b) {
		let componentsA = [...systemComponents.get(a).keys()];
		let componentsB = [...systemComponents.get(b).keys()];
		if (componentsA.length != componentsB.length)
			return componentsB.length - componentsA.length; // DESC components count
		return a.localeCompare(b);                          // alphabetically
	});
	for (let system of systemsSorted) {
		console.log(system);
		// sort components
		let componentsSorted = [...systemComponents.get(system).keys()].sort(function (a, b) {
			let subcomponentsA = [...systemComponents.get(system).get(a)];
			console.log(subcomponentsA);
			let subcomponentsB = [...systemComponents.get(system).get(b)];
			console.log(subcomponentsB);

			return subcomponentsB.length - subcomponentsA.length;  // DESC subcomponents count
		});
		for (let component of componentsSorted) {
			console.log(`|||${component}`);
			for (let subcomponent of systemComponents.get(system).get(component))
				console.log(`||||||${subcomponent}`);
		}
	}
}
systemComponents([
	'SULS | Main Site | Home Page',
	'SULS | Main Site | Login Page',
	'SULS | Main Site | Register Page',
	'SULS | Judge Site | Login Page',
	'SULS | Judge Site | Submittion Page',
	'Lambda | CoreA | A23',
	'SULS | Digital Site | Login Page',
	'Lambda | CoreB | B24',
	'Lambda | CoreA | A24',
	'Lambda | CoreA | A25',
	'Lambda | CoreC | C4',
	'Indice | Session | Default Storage',
	'Indice | Session | Default Security'
]);

function usernames(arr) {
	let usernames = new Set();
	for (let username of arr)
		usernames.add(username);
	console.log([...usernames]
		.sort((a, b) => a.localeCompare(b))
		.sort((a, b) => a.length - b.length)
		// .sort(sortByLengthAlpha)
		.join('\n'));

	function sortByLengthAlpha(a, b) {
		if (a.length != b.length)
			return a.length - b.length; // ASC length
		return a.localeCompare(b);      // alphabetically
	}
}
usernames([
	'Denise',
	'Ignatius',
	'Iris',
	'Isacc',
	'Indie',
	'Dean',
	'Donatello',
	'Enfuego',
	'Benjamin',
	'Biser',
	'Bounty',
	'Renard',
	'Rot'
]);


function uniqueSequences(arr) {
	let uniqueSeqs = new Map(); // length - sequence
	for (let line of arr) {
		let seq = JSON.parse(line).map(Number);
		// let seq = line.split(/\s*[,[\]]\s*/g).map(Number);
		// seq = seq.slice(1, seq.length - 1); // removing first & last non-arr elements
		seq.sort((a, b) => b - a);  // DESC
		let length = seq.length;
		if (!uniqueSeqs.has(length))
			uniqueSeqs.set(length, new Set());
		uniqueSeqs.get(length).add(`[${seq.join(', ')}]`);
	}
	let lengthKeys = [...uniqueSeqs.keys()].sort((a, b) => a - b);  // ASC
	for (let len of lengthKeys)
		for (let seq of uniqueSeqs.get(len))
			console.log(seq);
}

uniqueSequences([
	'[-3, -2, -1, 0, 1, 2, 3, 4]',
	'[10, 1, -17, 0, 2, 13]',
	'[4, -3, 3, -2, 2, -1, 1, 0]'
]);

uniqueSequences([
	'[7.14, 7.180, 7.339, 80.099]',
	'[7.339, 80.0990, 7.140000, 7.18]',
	'[7.339, 7.180, 7.14, 80.099]'
]);