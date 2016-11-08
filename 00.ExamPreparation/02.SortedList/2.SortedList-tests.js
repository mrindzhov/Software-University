let sortedList = require("../02.SortedList/2.SortedList").SortedList;
let expect = require("chai").expect;

describe("SortedList tests",function () {
    let sortedList;
    beforeEach(function () {
        sortedList = new SortedList();
    });

    it("has own property add()",function () {
        expect(SortedList.prototype.hasOwnProperty('add')).to.equal(true, "Function add() was not found");
    });
    it("has own property remove()",function () {
        expect(SortedList.prototype.hasOwnProperty('remove')).to.equal(true, "Function remove() was not found");
    });
    it("has own property get()",function () {
        expect(SortedList.prototype.hasOwnProperty('get')).to.equal(true, "Function get() was not found");
    });
    it("has own property vrfyRange()",function () {
        expect(SortedList.prototype.hasOwnProperty('vrfyRange')).to.equal(true, "Function vrfyRange() was not found");
    });
    it("has own property sort()",function () {
        expect(SortedList.prototype.hasOwnProperty('sort')).to.equal(true, "Function sort() was not found");
    });
    it("has own property size()",function () {
        expect(SortedList.prototype.hasOwnProperty('size')).to.equal(true, "Function size() was not found");
    });
    
    
    it("add one number should return lenght 1",function () {
        sortedList.add(5);
        expect(sortedList.size).to.equal(1);
    });
    it("add 4 and remove 1 number should return lenght 3",function () {
        sortedList.add(5);
        sortedList.add(7);
        sortedList.add(9);
        sortedList.add(11);
        sortedList.remove(0);
        expect(sortedList.size).to.equal(3);
    });
    it("add one number should return lenght 1",function () {
        sortedList.add(5);
        sortedList.add(7);
        sortedList.add(9);
        sortedList.add(11);
        let num = sortedList.get(3);
        expect(num).to.equal(11);
    });
    it("add numbers not sorted should return correct one",function () {
        sortedList.add(-5);
        sortedList.add(2);
        sortedList.add(-9);
        sortedList.add(18);
        let num = sortedList.get(0);
        expect(num).to.equal(-9);
    });
    it('should throw an error on negative index provided', () => {
        sortedList.add(-5);
        sortedList.add(2);
        sortedList.add(-9);
        sortedList.add(18);
        expect(() => {
            sortedList.get(-5)
        }).to.throw(Error);
    });
    it('should throw an error on index out of range', () => {
        sortedList.add(-5);
        sortedList.add(2);
        sortedList.add(-9);
        sortedList.add(18);
        expect(() => {
            sortedList.get(500)
        }).to.throw(Error);
    });
    it ('should throw an error if remove from empty collection', () => {
        expect(() => sortedList.remove(0)).to.throw('Collection is empty.')
    });
});