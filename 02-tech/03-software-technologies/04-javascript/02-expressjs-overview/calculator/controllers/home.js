const Calculator = require('../models/Calculator');

module.exports = {
    indexGet: (request, response) =>
    {
        response.render('home/index');
    },
    indexPost: (request, response) =>
    {
        const { leftOperand, operator, rightOperand } = request.body['calculator'];

        const calculator = new Calculator(Number(leftOperand), operator, Number(rightOperand));
        const result = calculator.calculate();

        response.render('home/index', { calculator, result });
    }
};