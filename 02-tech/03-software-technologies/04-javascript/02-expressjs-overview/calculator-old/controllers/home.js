const Calculator = require('./../models/calculator.js');

module.exports = {
    indexGet: (request, response) =>
    {
        response.render('home/index');
    },
    indexPost: (request, response) =>
    {
        const { leftOperand, operator, rightOperand } = request.body['calculator'];

        const calculator = new Calculator(leftOperand, operator, rightOperand);
        const result = calculator.calculateResult();

        response.render('home/index', { calculator, result });
    }
};