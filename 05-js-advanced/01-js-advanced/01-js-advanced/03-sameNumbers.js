function printIfNumberIsMadeOfRepeatingDigits(number)
{
    'use strict';

    const digits = String(number);
    let allDigitsAreTheSame = true;
    let digitsSum = 0;

    const lastDigit = String(digits)
        .length - 1;
    for (let current = 0; current < lastDigit; ++current)
    {
        const currentDigit = digits[current];
        const nextDigit = digits[current + 1];

        if (currentDigit !== nextDigit)
        {
            allDigitsAreTheSame = false;
            break;
        }
    }

    for (let digit of digits)
    {
        digitsSum += parseInt(digit, 10);
    }

    console.log(allDigitsAreTheSame);
    console.log(digitsSum);
}