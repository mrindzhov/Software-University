function solve() {
    class Melon {
        constructor(weight, melonSort) {
            if (new.target === Melon) {
                throw new TypeError("Abstract class cannot be instantiated directly");
            }

            this.weight = weight;
            this.melonSort = melonSort;
        }
    }

    class Watermelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort);
            this.element = 'Water';
            this._elementIndex = Number(weight) * Number(melonSort.toString().length);
        }

        get elementIndex() {
            return this._elementIndex;
        }

        toString(){
            return `Element: ${this.element}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
        }
    }

    class Firemelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort);
            this.element = 'Fire';
            this._elementIndex = Number(weight) * Number(melonSort.toString().length);
        }

        get elementIndex() {
            return this._elementIndex;
        }

        toString(){
            return `Element: ${this.element}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
        }
    }

    class Earthmelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort);
            this.element = 'Earth';
            this._elementIndex = Number(weight) * Number(melonSort.toString().length);
        }

        get elementIndex() {
            return this._elementIndex;
        }

        toString(){
            return `Element: ${this.element}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
        }
    }

    class Airmelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort);
            this.element = 'Air';
            this._elementIndex = Number(weight) * Number(melonSort.toString().length);
        }

        get elementIndex() {
            return this._elementIndex;
        }

        toString(){
            return `Element: ${this.element}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
        }
    }

    class Melolemonmelon extends Watermelon{
        constructor(weight, melonSort){
            super(weight, melonSort);
            this.type = this.element;
            this.counter = 0;
        }
        morph(){
            this.counter++;
            if(this.counter % 4 == 0){
                this.element = 'Water'
            }else if (this.counter % 4 == 1){
                this.element = 'Fire'
            }else if (this.counter % 4 == 2){
                this.element = 'Earth'
            }else if (this.counter % 4 == 3){
                this.element = 'Air'
            }
        }
        toString(){
            return `Element: ${this.element}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
        }
    }

    return {
        Melon,
        Watermelon,
        Firemelon,
        Earthmelon,
        Airmelon,
        Melolemonmelon
    }
}