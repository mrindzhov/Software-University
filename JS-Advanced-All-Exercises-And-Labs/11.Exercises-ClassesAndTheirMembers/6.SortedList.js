class SortedList {
    constructor() {
        this.collection = [];
        this.size = 0;
    }
    add(element) {
        this.collection.push(element);
        this.size++;
        this.sort();
    }
    remove(index) {
        if (index >= 0 && index < this.collection.length) {
            this.collection.splice(index, 1);
            this.sort();
            this.size--;
        } else {
            throw new Error;
        }
    }

    get(index) {
        if (index >= 0 && index < this.collection.length) {
            return this.collection[index];
        } else {
            throw new Error;
        }
    }
    sort() {
        this.collection = this.collection.sort((a, b) => a - b);
    }
}