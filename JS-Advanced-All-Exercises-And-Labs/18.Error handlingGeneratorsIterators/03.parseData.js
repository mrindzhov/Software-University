function makeCandy(arr) {
    class Candy {
        constructor(topping, filling, spice) {
            this.topping = topping;
            this.filling = filling;
            this.spice = spice;
        }
    }
    let result = [];
    let fillingOptions = ['hazelnut', 'caramel', 'strawberry', 'blueberry', 'yogurt', 'fudge', ''];
    let toppingOptions = ['milk chocolate', 'white chocolate', 'dark chocolate'];
    // console.log(arr);
    for (let element of arr) {
            element = element.split(':');
        if (element.length==3) {
            let isValid = true;
            let topping = element[0];
            if (!toppingOptions.includes(topping)) {
                isValid = false;
            }

            let filling = element[1].split(',');
            if (!fillingOptions.includes(...filling) || filling.length > 3) {
                isValid = false;
            }
            if (filling == "") {
                filling = null;
            }
            else {
                filling = filling.join(',');
            }

            let spice = element[2];
            if (spice == 'poison' || spice == 'asbestos') {
                isValid = false;
            }
            if (spice == '') {
                spice = null;
            }
            if (isValid) {
                result.push(new Candy(topping, filling, spice));
            }
        }

    }
    return result;
}
/*
console.log(makeCandy([
    'milk chocolate:hazelnut,caramel:pumpkin',
    'dark chocolate::chips',
    '',
    'white chocolate::poison',  // invalid
    'white chocolate:fudge:',
    'frosting:yogurt:frosting', // invalid
    'dark chocolate:blueberry:rock crystals']));*/
/*function makeCandy(arr) {
    class Candy {
        constructor(topping, filling, spice) {
            this.topping = topping;
            this.filling = filling;
            this.spice = spice;
        }
        set topping(value){
            let toppingOptions = ['milk chocolate', 'white chocolate', 'dark chocolate'];
            if (!toppingOptions.includes(value)) {
                throw new TypeError('Invalid topping');
            }
            this._topping=value;
        }
        get topping(){
            return this._topping;
        }
        set filling(value) {
            let fillingOptions = ['hazelnut', 'caramel', 'strawberry', 'blueberry', 'yogurt', 'fudge'];
            if (value.length > 3) {
                throw new TypeError('Invalid filling length');
            }
            if (!fillingOptions.includes(value)) {
                throw new TypeError('Invalid fillings');
            }
            if (value == "") {
                value = null;
            }else{
                value=value.join(',');
            }
            this._filling = value;
        }
        get filling(){
            return this._filling;
        }
        set spice(value){
            this._spice=value;
        }
        get spice(){
            return this._spice;
        }
    }
    let result = [];

    for (let element of arr) {
        element = element.split(':');
        let isValid = true;
        let topping = element[0];

        let filling = element[1].split(',');




        let spice = element[2];
        if (spice == 'poison' || spice == 'asbestos') {
            isValid = null;
        }
        if(spice==''){
            spice=null;
        }
        if (isValid) {
            result.push(new Candy(topping, filling, spice));
        }
    }
    return result;
}*/
