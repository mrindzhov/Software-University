let mathEnforcer = require("../3.MathEnforcer").mathEnforcer;
let expect = require("chai").expect;

describe("We will test mathEnforcer",function () {
    describe("addFive",function () {
        it("with non-number parameter should return undefined",function () {
            expect(mathEnforcer.addFive('pesho')).to.be.equal(undefined);
        });
        it("with non-number parameter should return undefined",function () {
            expect(mathEnforcer.addFive(5)).to.be.equal(10);
        });
        it("with non-number parameter should return undefined",function () {
            expect(mathEnforcer.addFive({name:'pesho'})).to.be.equal(undefined);
        });
        it("with non-number parameter should return undefined",function () {
            assert.closeTo(mathEnforcer.addFive(5.04),10.04,0.01)
        });
        it("with non-number parameter should return undefined",function () {
            assert.closeTo(mathEnforcer.addFive(-5.04),-0.04,0.01)
        });
        it("with non-number parameter should return undefined",function () {
            assert.closeTo(mathEnforcer.addFive(-3.04),2.96,0.01)
        });
    });
    describe("substractTen",function () {
        it("with non-number parameter should return undefined",function () {
            expect(mathEnforcer.subtractTen('pesho')).to.be.equal(undefined);
        });
        it("with non-number parameter should return undefined",function () {
            expect(mathEnforcer.subtractTen(5)).to.be.equal(-5);
        });
        it("with non-number parameter should return undefined",function () {
            expect(mathEnforcer.subtractTen(15)).to.be.equal(5);
        });
        it("with non-number parameter should return undefined",function () {
            expect(mathEnforcer.subtractTen({name:'pesho'})).to.be.equal(undefined);
        });
        it("with non-number parameter should return undefined",function () {
            assert.closeTo(mathEnforcer.subtractTen(5.04),-5.04,0.01)
        });
        it("with non-number parameter should return undefined",function () {
            assert.closeTo(mathEnforcer.subtractTen(-5.04),-15.04,0.01)
        });
        it("with non-number parameter should return undefined",function () {
            assert.closeTo(mathEnforcer.subtractTen(12.04),2.04,0.01)
        });
    });
    describe("sum",function () {
        it("with non-number parameter should return undefined",function () {
            expect(mathEnforcer.sum('pesho',5)).to.be.equal(undefined);
        });
        it("with non-number parameter should return undefined",function () {
            expect(mathEnforcer.sum(5,'peas')).to.be.equal(undefined);
        });
        it("with non-number parameter should return undefined",function () {
            expect(mathEnforcer.sum(15,13)).to.be.equal(28);
        });
        it("with non-number parameter should return undefined",function () {
            expect(mathEnforcer.sum(15,-13)).to.be.equal(2);
        });
        it("with non-number parameter should return undefined",function () {
            expect(mathEnforcer.sum(-3,-5)).to.be.equal(-8);
        });
        it("with non-number parameter should return undefined",function () {
            expect(mathEnforcer.sum({name:'pesho'},5)).to.be.equal(undefined);
        });
        it("with non-number parameter should return undefined",function () {
            expect(mathEnforcer.sum(5,{name:'pesho'})).to.be.equal(undefined);
        });
        it("with non-number parameter should return undefined",function () {
            assert.closeTo(mathEnforcer.sum(12.04,5),17.04,0.01)
        });
        it("with non-number parameter should return undefined",function () {
            assert.closeTo(mathEnforcer.sum(12.04,5.12),17.16,0.01)
        });
        it("with non-number parameter should return undefined",function () {
            assert.closeTo(mathEnforcer.sum(-12.24,5.12),7.12,0.01)
        });
        it("with non-number parameter should return undefined",function () {
            assert.closeTo(mathEnforcer.sum(-12.24,-5.12),-17.36,0.01)
        });
    });
});