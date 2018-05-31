const mocha = require('mocha');
const expect = require('chai').expect;
const SortedList = require('../sorted-list').SortedList;

describe("SortedList tests", function () {
    let sortedList;
    beforeEach(() => {
        sortedList = new SortedList();
    });

    it('should have all function', function () {
        expect(typeof sortedList.add).to.equal('function', 'Missing add function');
        expect(typeof sortedList.remove).to.equal('function', 'Missing remove function');
        expect(typeof sortedList.get).to.equal('function', 'Missing get function');
        expect(typeof sortedList.vrfyRange).to.equal('function', 'Missing vrfyRange function');
        expect(typeof sortedList.sort).to.equal('function', 'Missing sort function');
    });
    it('should sort correctly', function () {
        sortedList.add(5);
        sortedList.add(52);
        sortedList.add(-5);
        expect(sortedList.list).to.eql([-5, 5, 52], 'Not sorting');
        expect(sortedList.size).to.eql(3, 'Not calculating size');
    });
    it('should vrfyRange correctly', function () {

        let emptyCollection = function () {
            sortedList.vrfyRange()
        };
        expect(emptyCollection).to.throw(Error, 'Collection is empty.');
        let removeNegative = function () {
            sortedList.add(-5);
            sortedList.remove(-5)
        };
        expect(removeNegative).to.throw(Error, 'Index was outside the bounds of the collection.');

        sortedList.add(5);
        let invalidIndex = function () {
            sortedList.vrfyRange(-1)
        };
        expect(invalidIndex).to.throw(Error, 'Index was outside the bounds of the collection.');
    });
    it('should add correctly', function () {
        sortedList.add(-5);
        expect(sortedList.size).to.equal(1, 'Add not working');
        sortedList.add(5);
        sortedList.add(52);
        expect(sortedList.size).to.equal(3, 'Add not working with multiple call');
    });
    it('should remove correctly', function () {
        expect(sortedList.size).to.equal(0, 'Add not working');
        sortedList.add(5);
        sortedList.add(52);
        expect(sortedList.size).to.equal(2, 'Add not working with multiple call');
    });
});
