const { expect } = require('chai');
const assert = require('assert');

const badResult = 'Function did not return the correct result!';

describe('isOddOrEven', function ()
{
    it('should return undefined with a number parameter', () =>
    {
        expect(isOddOrEven(12)).to.equal(undefined, badResult);
    });

    it('should return undefined with an object parameter', () =>
    {
        isOddOrEven({ name: 'George' }).should.equal(undefined, badResult);
    });

    it('should return correct result with an even length', () =>
    {
        assert.equal(isOddOrEven('roar'), 'even', badResult);
    });

    it('should return correct result with an odd length', () =>
    {
        expect(isOddOrEven('Peter')).to.equal('odd', badResult);
    });

    it('should return correct values with multiple consecutive checks', () =>
    {
        expect(isOddOrEven('cat')).to.equal('odd', badResult);
        expect(isOddOrEven('pet')).to.equal('odd', badResult);
        expect(isOddOrEven('bird')).to.equal('even', badResult);
    });
});