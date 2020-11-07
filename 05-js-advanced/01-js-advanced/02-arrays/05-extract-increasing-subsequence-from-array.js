function printIncreasingSubsequence(numbers)
{
    const increasingSubsequence = [];
    let maxNumber = Number.MIN_SAFE_INTEGER;

    for (const currentNumber of numbers)
    {
        if (currentNumber >= maxNumber)
        {
            increasingSubsequence.push(currentNumber);

            maxNumber = currentNumber;
        }
    }

    for (const number of increasingSubsequence)
    {
        console.log(number);
    }
}