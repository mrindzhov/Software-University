let Console = require("../5.CSharpConsole/5.CSharpConsole").Console;
let expect = require("chai").expect;

describe("Console tests",function () {
    it('should have method writeLine', () => {
        expect(typeof Console.writeLine).to.equal('function');
    });
    it("One argument Test", () =>  {
        let res = Console.writeLine('pesho');
        expect(res).to.equal('pesho');
    });
    it('Two parameters Test should return TypeError', () => {
        expect(() => Console.writeLine(123, 'test')).to.throw(TypeError);
    });
    it('JSON Test', () => {
        let obj = {'name': 'Pesho'};
        let res = Console.writeLine(obj);
        expect(res).to.equal(JSON.stringify(obj));
    });
    it('Parameters Test', () => {
        let res = Console.writeLine('{0}, {1}, {2}', 'Pesho', 'Gosho', 'Stamat');
        expect(res).to.equal('Pesho, Gosho, Stamat');
    });
    it('Parameter Test should return error', () => {
        expect(() => Console.writeLine('Test {50}', 'Gosho')).to.throw(RangeError);
    });
   
});