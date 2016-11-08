(function solve() {
    let nextId = 0;

    class Extensible {
        constructor() {
            this.id = nextId;
            nextId++;
        }

        extend(template) {
            for (let prop in template) {
                if (template.hasOwnProperty(prop)) {
                    if (typeof template[prop] == 'function') {
                        Object.getPrototypeOf(this)[prop] = template[prop]
                    } else {
                        this[prop] = template[prop]
                    }
                }
            }
        }

    }
    return Extensible;
})();

var template = {
    extensionData: 5,
    extensionMethod: function (value) {
        return value + 1;
    }
};

let testObj = new Extensible();
console.log(testObj.id);

testObj.extend(template);

console.log(testObj.hasOwnProperty('extensionData'));
console.log(testObj.extensionData);
console.log(Object.getPrototypeOf(testObj));
console.log(testObj.extensionMethod(1));