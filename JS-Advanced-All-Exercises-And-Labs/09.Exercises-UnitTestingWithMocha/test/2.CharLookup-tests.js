let lookupChar = require("../2.CharLookup.js").lookupChar;
let expect = require("chai").expect;

describe("lookupChar", function() {
    it("with a non-string first parameter, should return correct message", function() {
        expect(lookupChar(13, 0)).to.equal(undefined,
            "The function did not return the correct message!");
    });
    it("with a non-number second parameter, should return correct message", function() {
        expect(lookupChar("pesho", "gosho")).to.equal(undefined,
            "The function did not return the correct message!");
    });
    it("with a floating poit second parameter, should return correct message", function() {
        expect(lookupChar("pesho", 3.12)).to.equal(undefined,
            "The function did not return the correct message!");
    });
    it("with an index value equal to string lenght, should return correct message", function() {
        expect(lookupChar("pesho", 5)).to.equal("Incorrect index",
            "The function did not return the correct message!");
    });
    it("with an incorrect index value, should return correct message", function() {
        expect(lookupChar("gosho", 13)).to.equal("Incorrect index",
            "The function did not return the correct message!");
    });
    it("with a negative index value, should return correct message", function() {
        expect(lookupChar("stamat", -1)).to.equal("Incorrect index",
            "The function did not return the correct message!");
    });
    it("with correct parameter, should return correct message", function() {
        expect(lookupChar("pesho", 0)).to.equal("p",
            "The function did not return the correct message!");
    });
    it("with correct parameter, should return correct message", function() {
        expect(lookupChar("stamat", 3)).to.equal("m",
            "The function did not return the correct message!");
    });
});