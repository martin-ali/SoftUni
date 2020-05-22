const { expect } = require('chai');
const assert = require('assert');

const badResult = 'the function did not return the correct result!';
const badIndex = 'Incorrect index';

describe('lookupChar', () =>
{
    it('should return undefined with a non-string first parameter', () =>
    {
        expect(lookupChar(13, 0)).to.equal(undefined, badResult);
    })

    it('should return undefined with a non-number second parameter', () =>
    {
        expect(lookupChar('Peter', 'George')).to.equal(undefined, badResult);
    });

    it('should return undefined with a floating-point number as a second parameter', () =>
    {
        expect(lookupChar('Peter', 3.12)).to.equal(undefined, badResult);
    });

    it('should return incorrect index with an incorrect index value', () =>
    {
        expect(lookupChar('George', 13)).to.equal(badIndex, badResult);
    });

    it('should return incorrect index with a negative index value', () =>
    {
        expect(lookupChar('Peter', -1)).to.equal(badIndex, badResult);
    });

    it('should return incorrect index with an index value equal to string length', () =>
    {
        expect(lookupChar('Peter', 5)).to.equal(badIndex, badResult);
    });

    it('should return correct value with correct parameters', () =>
    {
        expect(lookupChar('Peter', 3)).to.equal('e', badResult);
    });

    it('should return correct value with correct parameters', () =>
    {
        expect(lookupChar('George', 0)).to.equal('G', badResult);
    });
});