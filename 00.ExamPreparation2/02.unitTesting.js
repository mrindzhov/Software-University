let list = (function(){
    let data = [];
    return {
        add: function(item) {
            data.push(item);
        },
        delete: function(index) {
            if (Number.isInteger(index) && index >= 0 && index < data.length) {
                return data.splice(index, 1)[0];
            } else {
                return undefined;
            }
        },
        toString: function() {
            return data.join(", ");
        }
    };
})();


let expect= require("chai").expect;
let assert=require('chai').assert;

describe("list", function() {
    describe("add", function () {
        it("TestAdd1", function () {
            list.add(5);
            list.add(15);
            expect(list.toString()).to.be.equal('5, 15');
        });
        it("TestAdd2", function () {
            list.add(5);
            expect(list.toString()).to.be.equal('5');
        });
        it("TestAdd3", function () {
            list.add('asd');
            expect(list.toString()).to.be.equal('asd');
        });
    });
    describe("delete", function () {
        it("TestDelete1", function () {
            expect( list.delete(-1)).to.be.undefined;
        });
        it("TestDelete2", function () {
            expect(list.delete(-45)).to.be.undefined;
        });
        it("TestDelete3", function () {
            expect(list.delete('jibry')).to.be.undefined;
        });
        it("TestDelete4", function () {
            list.add(5);list.add(124);list.add('asdasfas');
            list.delete(2);
            expect(list.toString()).to.be.equal(`5, 124`);
        });
        it("TestDelete4", function () {
            list.add(5);list.add(124);list.add('asdasfas');
            list.delete(0);
            expect(list.toString()).to.be.equal(`124, asdasfas`);
        });
    });
    describe("toString", function () {
        it("TestString1", function () {
            list.add(5);list.add(124);list.add('asdasfas');
            expect(list.toString()).to.be.equal(`5, 124, asdasfas`);
        });
        it("TestString1", function () {
            list.add(5);list.delete(0);
            expect(list.toString()).to.be.equal(``);
        });
    });
});
