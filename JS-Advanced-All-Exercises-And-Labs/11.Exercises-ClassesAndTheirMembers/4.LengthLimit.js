class Stringer{
    constructor(innerString , innerLength){
        this.innerString  = innerString ;
        this.innerLength = innerLength;
    }

    increase(innerLength) {
        this.innerLength += innerLength;
    }

    decrease(innerLength){
        this.innerLength -= innerLength;
        if (this.innerLength < 0){
            this.innerLength = 0
        }
    }
    toString() {
        if (this.innerLength == 0) {
            return '...';
        }else {
            return this.innerString.substr(0, this.innerLength) + '...';
        }
    }
}