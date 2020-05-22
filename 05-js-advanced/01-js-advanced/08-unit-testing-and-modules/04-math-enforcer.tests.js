const { expect } = require('chai');
const assert = require('assert');

const badResult = 'Function did not return the correct result!';

describe('mathEnforcer', () =>
{
    describe('addFive', () =>
    {
        it('should return correct result with a non-number parameter', () =>
        {
            expect(mathEnforcer.addFive('Orange')).to.equal(undefined, badResult);
        });

        it('should return correct result with a number parameter', () =>
        {
            expect(mathEnforcer.addFive(5)).to.equal(10, badResult);
        });

        it('should return correct result with a negative number parameter', () =>
        {
            expect(mathEnforcer.addFive(-5)).to.equal(0, badResult);
        });

        it('should return correct result with a floating-point parameter', () =>
        {
            expect(mathEnforcer.addFive(5.1)).to.be.closeTo(10.1, 0.01, badResult);
        });
    });

    describe('subtractTen', () =>
    {
        it('should return correct result with a non-number parameter', () =>
        {
            expect(mathEnforcer.subtractTen('Apple')).to.equal(undefined, badResult);
        });

        it('should return correct result with a number parameter', () =>
        {
            expect(mathEnforcer.subtractTen(15)).to.equal(5, badResult);
        });

        it('should return correct result with a negative number parameter', () =>
        {
            expect(mathEnforcer.subtractTen(-15)).to.equal(-25, badResult);
        });

        it('should return correct result with a floating-point parameter', () =>
        {
            expect(mathEnforcer.subtractTen(15.1)).to.be.closeTo(5.1, 0.01, badResult);
        });
    });

    describe('sum', () =>
    {
        it('should return correct result with a non-number first and non-number second parameter', () =>
        {
            expect(mathEnforcer.sum('a', 'b')).to.be.equal(undefined, badResult);
        });

        it('should return correct result with a number first and non-number second parameter', () =>
        {
            expect(mathEnforcer.sum(1, 'b')).to.be.equal(undefined, badResult);
        });

        it('should return correct result with a non-number first and number second parameter', () =>
        {
            expect(mathEnforcer.sum('a', 1)).to.be.equal(undefined, badResult);
        });

        it('should return correct result with a floating-point first and non-number second parameter', () =>
        {
            expect(mathEnforcer.sum(1.1, 'b')).to.be.equal(undefined, badResult);
        });

        it('should return correct result with a non-number first and floating-point second parameter', () =>
        {
            expect(mathEnforcer.sum('a', 1.1)).to.be.equal(undefined, badResult);
        });

        it('should return correct result with a number first and number second parameter', () =>
        {
            expect(mathEnforcer.sum(2, 1)).to.equal(3, badResult);
        });

        it('should return correct result with a floating-point first and number second parameter', () =>
        {
            expect(mathEnforcer.sum(2.1, 1)).to.be.closeTo(3.1, 0.01, badResult);
        });

        it('should return correct result with a number first and floating-point second parameter', () =>
        {
            expect(mathEnforcer.sum(2, 1.1)).to.be.closeTo(3.1, 0.01, badResult);
        });

        it('should return correct result with both floating-point parameters', () =>
        {
            expect(mathEnforcer.sum(2.1, 1.1)).to.be.closeTo(3.2, 0.01, badResult);
        });
    });
});