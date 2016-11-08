class Rectangle {
    constructor(width, height, color) {
        [this.width, this.height, this.color] = [width, height, color];
    }
    calcArea(){
        return this.width * this.height;
    }
}

let rect = new Rectangle(5, 4, 'red');

console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());


