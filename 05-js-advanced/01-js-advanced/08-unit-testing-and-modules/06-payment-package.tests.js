const { expect } = require('chai');
const assert = require('assert');

describe('PaymentPackage', () =>
{
    it('should have all necessary members', () =>
    {
        expect(PaymentPackage.prototype).to.have.property('name');
        expect(PaymentPackage.prototype).to.have.property('value');
        expect(PaymentPackage.prototype).to.have.property('VAT');
        expect(PaymentPackage.prototype).to.have.property('active');
        expect(PaymentPackage.prototype).to.have.property('toString');
    });

    describe('constructor', () =>
    {
        it('should initialize properly', () =>
        {
            const package = new PaymentPackage('name', 22);

            expect(package.name).to.equal('name');
            expect(package.value).to.equal(22);
            expect(package.VAT).to.equal(20);
            expect(package.active).to.equal(true);
            expect(package).to.be.an.instanceof(PaymentPackage);
        });

        it('should throw with non-string name', () =>
        {
            expect(() => new PaymentPackage(true, 22)).to.throw();
        });

        it('should throw with non-number value', () =>
        {
            expect(() => new PaymentPackage('name', true)).to.throw();
        });
    });

    describe('name', () =>
    {
        it('should get correct name', () =>
        {
            const package = new PaymentPackage('name', 2123);

            expect(package.name).to.equal('name');
        });

        it('should set correct name', () =>
        {
            const package = new PaymentPackage('name', 2123);
            package.name = 'newName';

            expect(package.name).to.equal('newName');
        });

        it('should throw with non-string name', () =>
        {
            const package = new PaymentPackage('name', 2123);

            expect(() => package.name = 54).to.throw();
        });

        it('should throw with empty name', () =>
        {
            const package = new PaymentPackage('name', 2123);

            expect(() => package.name = '').to.throw();
        });
    });

    describe('value', () =>
    {
        it('should get correct value', () =>
        {
            const package = new PaymentPackage('name', 2123);

            expect(package.value).to.equal(2123);
        });

        it('should get correct value with zero', () =>
        {
            const package = new PaymentPackage('name', 0);

            expect(package.value).to.equal(0);
        });

        it('should set correct value', () =>
        {
            const package = new PaymentPackage('name', 2123);
            package.value = 3;

            expect(package.value).to.equal(3);
        });

        it('should throw with non-number value', () =>
        {
            const package = new PaymentPackage('name', 2123);

            expect(() => package.value = 'Peter').to.throw();
        });

        it('should throw with negative value', () =>
        {
            const package = new PaymentPackage('name', 2123);

            expect(() => package.value = -1).to.throw();
        });
    });

    describe('VAT', () =>
    {
        it('should get correct VAT', () =>
        {
            const package = new PaymentPackage('name', 2123);

            expect(package.VAT).to.equal(20);
        });

        it('should set correct VAT', () =>
        {
            const package = new PaymentPackage('name', 2123);
            package.VAT = 3;

            expect(package.VAT).to.equal(3);
        });

        it('should throw with non-number VAT', () =>
        {
            const package = new PaymentPackage('name', 2123);

            expect(() => package.VAT = 'Peter').to.throw();
        });

        it('should throw with negative VAT', () =>
        {
            const package = new PaymentPackage('name', 2123);

            expect(() => package.VAT = -1).to.throw();
        });
    });

    describe('active', () =>
    {
        it('should get correct active', () =>
        {
            const package = new PaymentPackage('name', 2123);

            expect(package.active).to.equal(true);
        });

        it('should set correct active', () =>
        {
            const package = new PaymentPackage('name', 2123);
            package.active = false;

            expect(package.active).to.equal(false);
        });

        it('should throw with non-boolean active', () =>
        {
            const package = new PaymentPackage('name', 2123);

            expect(() => package.active = 54).to.throw();
        });
    });

    describe('toString', () =>
    {
        it('should get correct value with active = true', () =>
        {
            const package = new PaymentPackage('name', 2123);

            expect(package.toString()).to.equal('Package: name\n- Value (excl. VAT): 2123\n- Value (VAT 20%): 2547.6');
        });

        it('should get correct value with active = false', () =>
        {
            const package = new PaymentPackage('name', 2123);
            package.active = false;

            expect(package.toString()).to.equal('Package: name (inactive)\n- Value (excl. VAT): 2123\n- Value (VAT 20%): 2547.6');
        });
    });
});