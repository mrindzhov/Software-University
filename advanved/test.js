let expect = require('chai').expect;

class Sumator {
    constructor() {
        this.data = [];
    }

    add(item) {
        this.data.push(item);
    }

    sumNums() {
        let sum = 0;
        for (let item of this.data)
            if (typeof (item) === 'number')
                sum += item;
        return sum;
    }

    removeByFilter(filterFunc) {
        this.data = this.data.filter(x => !filterFunc(x));
    }

    toString() {
        if (this.data.length > 0)
            return this.data.join(", ");
        else
            return '(empty)';
    }
}

describe('Sumator', function () {
    let myList;

    beforeEach(function () {
        myList = new Sumator();
    });

    it('has all properties', function () {
        expect(myList.hasOwnProperty('data')).to.equal(true, "Missing data property");
    });

    it('has functions attached to prototype', function () {
        console.log(typeof myList.add);
        expect(typeof myList.add).to.equal('function', "Missing add function");
        expect(typeof myList.sumNums).to.equal('function', "Missing sumNums function");
        expect(typeof myList.removeByFilter).to.equal('function', "Missing removeByFilter function");
        expect(typeof myList.toString).to.equal('function', "Missing toString function");
    });

    it('must initialize data to an empty array', function () {
        expect(myList.data instanceof Array).to.equal(true, 'Data must be of type array');
        expect(myList.data.length).to.equal(0, 'Data array ust be initialized empty');
    });

    it('can add a number', function () {
        myList.add(4);
        expect(myList.data.length).to.equal(1, "Element wasn't added");
    });

    it('can add several items of different types', function () {
        myList.add(4);
        expect(myList.data.length).to.equal(1, "Element wasn't added");
        myList.add('pesho');
        expect(myList.data.length).to.equal(2, "Element wasn't added");
        myList.add([1, 2, 3]);
        expect(myList.data.length).to.equal(3, "Element wasn't added");
    });

    it('returns 0 when empty', function () {
        expect(myList.sumNums()).to.equal(0, "Incorrect sum when empty");
    });

    it('correctly sums numbers', function () {
        myList.add(4);
        myList.add(5);
        myList.add(6);
        expect(myList.sumNums()).to.equal(15, "Sum isn't correct");
    });

    it('correctly filters non-numbers when summing', function () {
        myList.add(4);
        myList.add('pesho');
        myList.add([1, 2, 3]);
        expect(myList.sumNums()).to.equal(4, "Didn't filter sum");
    });

    it('removes all matching elements', function () {
        myList.add(4);
        myList.add('pesho');
        myList.add(4);
        myList.removeByFilter((e) => e === 4);
        expect(myList.data).to.not.contains(4, "Element not removed");
    });

    it('toString returns (empty) when empty', function () {
        expect(myList.toString()).to.equal('(empty)', "toString didn't remove (empty)");
    });

    it('toString returns correct elements', function () {
        myList.add(4);
        myList.add('pesho');
        myList.add('gosho');
        expect(myList.toString()).to.equal('4, pesho, gosho', "toString didn't work correctly");
    });
});