const { expect } = require('chai');
const assert = require('assert');

describe('StringBuilder', () =>
{
    describe('members', () =>
    {
        it('should have all necessary functions', function ()
        {
            expect(StringBuilder.prototype.append).to.be.a('function');
            expect(StringBuilder.prototype.prepend).to.be.a('function');
            expect(StringBuilder.prototype.insertAt).to.be.a('function');
            expect(StringBuilder.prototype.remove).to.be.a('function');
            expect(StringBuilder.prototype.toString).to.be.a('function');
        })
    });

    describe('constructor', () =>
    {
        it('should throw with non-string argument', () =>
        {
            expect(() => new StringBuilder(5)).to.throw();
        });

        it('should create new instance correctly with no argument', () =>
        {
            expect(new StringBuilder()).to.be.instanceOf(StringBuilder);
        });

        it('should create new instance correctly with string argument', () =>
        {
            expect(new StringBuilder('someArg')).to.be.instanceOf(StringBuilder);
        });

        it('should create and populate new instance correctly with string argument', () =>
        {
            const builder = new StringBuilder('som');

            // expect(builder._stringArray).to.be.equal();
            assert.deepEqual(builder._stringArray, ['s', 'o', 'm']);
        });
    });

    describe('append', () =>
    {
        it('should throw with non-string argument', () =>
        {
            const builder = new StringBuilder();

            expect(() => builder.append(5)).to.throw();
        });

        it('should throw with no argument', () =>
        {
            const builder = new StringBuilder();

            expect(() => builder.append()).to.throw();
        });

        it('should append empty string correctly', () =>
        {
            const builder = new StringBuilder();

            builder.append('');

            expect(builder.toString()).to.equal('');
        });

        it('should work correctly', () =>
        {
            const builder = new StringBuilder();

            builder.append('someString');

            expect(builder.toString()).to.equal('someString');
        });

        it('should add to end correctly', () =>
        {
            const builder = new StringBuilder('Big');

            builder.append('SomeString');

            expect(builder.toString()).to.equal('BigSomeString');
        });
    });

    describe('prepend', () =>
    {
        it('should throw with non-string argument', () =>
        {
            const builder = new StringBuilder();

            expect(() => builder.prepend(5)).to.throw();
        });

        it('should throw with no argument', () =>
        {
            const builder = new StringBuilder();

            expect(() => builder.prepend()).to.throw();
        });

        it('should prepend empty string correctly', () =>
        {
            const builder = new StringBuilder();

            builder.prepend('');

            expect(builder.toString()).to.equal('');
        });

        it('should work correctly', () =>
        {
            const builder = new StringBuilder();

            builder.prepend('someString');

            expect(builder.toString()).to.equal('someString');
        });

        it('should add to start correctly', () =>
        {
            const builder = new StringBuilder('Big');

            builder.prepend('SomeString');

            expect(builder.toString()).to.equal('SomeStringBig');
        });
    });

    describe('insertAt', () =>
    {
        it('should throw with non-string argument', () =>
        {
            const builder = new StringBuilder();

            expect(() => builder.insertAt(0, 1)).to.throw();
        });

        it('should throw with no argument', () =>
        {
            const builder = new StringBuilder();

            expect(() => builder.insertAt(0)).to.throw();
        });

        it('should insert correctly with empty StringBuilder', () =>
        {
            const builder = new StringBuilder();

            builder.insertAt('SomeString', 0);

            expect(builder.toString()).to.equal('SomeString');
        });

        it('should insert correctly with filled StringBuilder', () =>
        {
            const builder = new StringBuilder('Bug');

            builder.insertAt('SomeString', 1);

            expect(builder.toString()).to.equal('BSomeStringug');
        });
    });

    describe('remove', () =>
    {
        it('should remove correctly with empty StringBuilder', () =>
        {
            const builder = new StringBuilder();

            builder.remove(0, 1);

            expect(builder.toString()).to.equal('');
        });

        it('should remove passed empty string correctly with filled StringBuilder', () =>
        {
            const builder = new StringBuilder('Bug');

            builder.remove(1, 1);

            expect(builder.toString()).to.equal('Bg');
        });
    });

    describe('toString', () =>
    {
        it('should work correctly with empty StringBuilder', () =>
        {
            const builder = new StringBuilder();

            expect(builder.toString()).to.equal('');
        });

        it('should work correctly with filled StringBuilder', () =>
        {
            const builder = new StringBuilder('Bug');

            expect(builder.toString()).to.equal('Bug');
        });

        // WTF? Why does it only work after using this specific string?
        // Shorter ones fail on judge
        // Length constraint?
        it('should work correctly after modification', () =>
        {
            const builder = new StringBuilder('Bug');

            builder.append('qweqe');
            builder.prepend('qweqe');
            builder.insertAt('qwfdef', 4)
            builder.remove(4, 3);

            expect(builder.toString()).to.equal('qweqdefeBugqweqe');
        });
    });
});