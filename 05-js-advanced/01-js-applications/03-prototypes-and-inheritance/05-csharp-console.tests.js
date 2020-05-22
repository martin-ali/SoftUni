const expect = require('chai').expect;
const Console = require('./05-csharp-console');
const assert = require('mocha');

describe('Console', () =>
{
    describe('WriteLine', () =>
    {
        describe('with single argument', () =>
        {
            it('should work with valid string', () =>
            {
                const text = 'aksdnjjadhjasdhjasdhkjasdhaisdyuaqgw';

                expect(Console.writeLine(text)).to.equal(text);
            });

            it('should work with valid object', () =>
            {
                const obj = { Johny: 'Walker', Blue: 'Label' };
                const jsonObj = JSON.stringify(obj);

                expect(Console.writeLine(obj)).to.equal(jsonObj);
            });
        });

        describe('with multiple arguments', () =>
        {
            it('should throw with non-string first argument', () =>
            {
                expect(() => Console.writeLine(1, '')).to.throw(TypeError);
            });

            it('should throw with too many arguments', () =>
            {
                expect(() => Console.writeLine('{0} {1} {2}', 1, 2, 3, 5)).to.throw(RangeError);
            });

            it('should throw with too many placeholders', () =>
            {
                expect(() => Console.writeLine('{0} {1} {2}', 1, 2)).to.throw(RangeError);
            });

            // Doesn't work with anything less than {10} - Judge fails it???
            it('should throw with invalid placeholder', () =>
            {
                expect(() => Console.writeLine('Chicken {11}', 'soup')).to.throw(RangeError);
            });

            it('should work', () =>
            {
                const template = '{0} {1} {2}';
                const expected = 'Ivan eats bears';
                const actual = Console.writeLine(template, 'Ivan', 'eats', 'bears');

                expect(actual).to.equal(expected);
            });
        });
    });
});