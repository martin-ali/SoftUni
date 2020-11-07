function getGreatestCommonDivisor(firstNumber, secondNumber)
{
    'use strict';

    const largestNumber = Math.max(firstNumber, secondNumber);
    let result = 0;

    for (let divisor = largestNumber; divisor > 0; divisor--)
    {
        if (firstNumber % divisor == 0
            && secondNumber % divisor == 0)
        {
            result = divisor;
            break;
        }
    }

    return result;
}