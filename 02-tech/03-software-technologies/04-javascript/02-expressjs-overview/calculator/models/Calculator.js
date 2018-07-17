class Calculator
{
    /**
     * @param {number} leftOperand
     * @param {string} operation
     * @param {number} rightOperand
     * @memberof Calculator
     */
    constructor(leftOperand, operation, rightOperand)
    {
        this.leftOperand = leftOperand;
        this.operator = operation;
        this.rightOperand = rightOperand;
    }

    /**
     * @returns {number}
     */
    calculate()
    {
        const operations = {
            '+': (a, b) => a + b,
            '-': (a, b) => a - b,
            '*': (a, b) => a * b,
            '/': (a, b) => a / b,
            '^': (a, b) => a ** b
        };

        const result = Number(this.operator in operations)
            && operations[this.operator](this.leftOperand, this.rightOperand);

        return result;
    }
}

module.exports = Calculator;