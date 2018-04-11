function Calculator(leftOperand, operator, rightOperand)
{
    'use strict';
    this.leftOperand = Number(leftOperand);
    this.operator = operator;
    this.rightOperand = Number(rightOperand);

    this.calculateResult = () =>
    {
        let result = 0;

        switch (this.operator)
        {
            case '+':
                result = this.leftOperand + this.rightOperand;
                break;
            case '-':
                result = this.leftOperand - this.rightOperand;
                break;
            case '*':
                result = this.leftOperand * this.rightOperand;
                break;
            case '/':
                result = this.leftOperand / this.rightOperand;
                break;
            case 'pow':
                result = this.leftOperand ** this.rightOperand;
                break;
        }

        return result;
    }
}

module.exports = Calculator;

// class Calculator
// {
//     'use strict';
//     constructor(leftOperand, operator, rightOperand)
//     {
//         this.leftOperand = leftOperand;
//         this.operator = operator;
//         this.rightOperand = rightOperand;
//     }

//     calculateResult()
//     {
//         let result = 0;

//         switch (this.operator)
//         {
//             case '+':
//                 result = this.leftOperand + this.rightOperand;
//                 break;
//             case '-':
//                 result = this.leftOperand - this.rightOperand;
//                 break;
//             case '*':
//                 result = this.leftOperand * this.rightOperand;
//                 break;
//             case '/':
//                 result = this.leftOperand / this.rightOperand;
//                 break;
//         }

//         return result;
//     }
// }

// export default Calculator;