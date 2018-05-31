function createList() {
    let data = [];
    return {
        add: function (item) {
            data.push(item)
        },
        shiftLeft: function () {
            if (data.length > 1) {
                let first = data.shift();
                data.push(first);
            }
        },
        shiftRight: function () {
            if (data.length > 1) {
                let last = data.pop();
                data.unshift(last);
            }
        },
        swap: function (index1, index2) {
            if (!Number.isInteger(index1) || index1 < 0 || index1 >= data.length ||
                !Number.isInteger(index2) || index2 < 0 || index2 >= data.length ||
                index1 === index2) {
                return false;
            }
            let temp = data[index1];
            data[index1] = data[index2];
            data[index2] = temp;
            return true;
        },
        toString: function () {
            return data.join(", ");
        }
    };
}
let expect = require("chai").expect;

describe("We will test createList()",function () {
    let list;
    beforeEach(function () {
        list = createList();
    });
    it("General Test1", function() {
        expect(typeof (list.add)).to.equal('function');
        expect(typeof (list.shiftLeft)).to.equal('function');
        expect(typeof (list.shiftRight)).to.equal('function');
        expect(typeof (list.toString)).to.equal('function');
    });
    it("General Test2",function () {
        expect(list.toString()).to.be.equal('');
    });
    describe("add",function () {
        it("Add test",function () {
            list.add('pesho');
            list.add(5);
            list.add();
            list.add(' ');
            expect(list.toString()).to.equal("pesho, 5, ,  ")
        });
    });
    describe("shiftLeft",function () {
        it("ShiftLeft Test1",function () {
            list.add('pesho');
            list.add(5);
            list.shiftLeft();
            list.shiftLeft();
            list.add(true);
            list.add(undefined);
            list.add(NaN);
            list.shiftLeft();
            expect(list.toString()).to.equal("5, true, , NaN, pesho")
        });
    });
    describe("shiftRight",function () {
        it("ShiftLeft Test1",function () {
            list.add('pesho');
            list.add(5);
            list.shiftRight();
            list.shiftRight();
            list.add(true);
            list.add(undefined);
            list.add(NaN);
            list.shiftRight();
            expect(list.toString()).to.equal("NaN, pesho, 5, true, ")
        });
        it("Shift MixTest",function () {
            let newList =createList();
            list.add('pesho');
            list.shiftLeft();
            list.shiftRight();
            expect(list.toString()).to.equal("pesho");
            expect(newList.toString()).to.equal("");
        });
    });
    describe("swap",function () {
        it("Swap Test1",function () {
            list.add('pesho');
            list.add('misho');
            list.add('gosho');
            list.add('prytiu');
            list.add(true);
            list.add('asdasd');
            list.shiftRight();
            expect(list.swap(-1,3)).to.equal(false);
            expect(list.swap(123,5)).to.equal(false);
            expect(list.swap(2,6)).to.equal(false);
            expect(list.swap(-1.54,6)).to.equal(false);
            expect(list.swap(-1,6.42)).to.equal(false);
            expect(list.swap(5,5)).to.equal(false);
            expect(list.swap('asd',5)).to.equal(false);
            expect(list.swap(5,'asd')).to.equal(false);
            expect(list.toString()).to.equal('asdasd, pesho, misho, gosho, prytiu, true');
        });
        it("Swap Test2",function () {
            list.add('pesho');
            list.add('misho');
            list.add('gosho');
            list.add('prytiu');
            list.add(true);
            list.add('asdasd');
            list.shiftRight();
            expect(list.swap(0,3)).to.equal(true);
            expect(list.swap(2,5)).to.equal(true);
            expect(list.toString()).to.equal('gosho, pesho, true, asdasd, prytiu, misho');
        });
    });
    describe("toString",function () {
        it("toString Test1",function () {
            list.add('pesho');
            list.add(true);
            list.add('kiro');
            list.swap(1,2);
            list.add('true4o');
            list.add('dylgaduma');
            list.shiftRight();
            list.swap(4,0);
            list.swap(1,4);
            expect(list.toString()).to.be.equal('true4o, dylgaduma, kiro, true, pesho');
            expect(list.swap(1,2)).to.equal(true);
            expect(list.swap(4,0)).to.equal(true);
            expect(list.swap(1,4)).to.equal(true);
        });
    });
});
