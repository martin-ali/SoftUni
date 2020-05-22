function solve(numbers, order)
{
    numbers.sort((a, b) =>
    {
        if (order === 'asc')
        {
            return a - b;
        }
        else // desc
        {
            return b - a;
        }

    });

    return numbers;
}