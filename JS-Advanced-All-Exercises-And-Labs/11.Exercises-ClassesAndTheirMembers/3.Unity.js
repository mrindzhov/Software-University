class Rat{
    constructor(name){
        this.name = name;
        this.arr = [];
    }

    unite(otherRat) {
        if(this.constructor == otherRat.constructor) {
            this.arr.push(otherRat);
        }
    }
    getRats() {
        return this.arr;
    }
    toString(){
        let res = this.name;
        for (let i = 0; i < this.arr.length; i++) {
            res += '\n##' + this.arr[i].name;
        }
        return res;
    }
}