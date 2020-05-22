function getMatrixMagicStatus(matrix)
{
    const sums = [];
    for (let row = 0; row < matrix.length; ++row)
    {
        let rowSum = 0;
        for (let col = 0; col < matrix[row].length; ++col)
        {
            rowSum += matrix[row][col]
        }

        sums.push(rowSum);
    }

    for (let col = 0; col < matrix.length; ++col)
    {
        let rowSum = 0;
        for (let row = 0; row < matrix.length; ++row)
        {
            rowSum += matrix[row][col]
        }

        sums.push(rowSum);
    }

    let matrixIsMagic = true;
    for (const sum of sums)
    {
        if (sum !== sums[0])
        {
            matrixIsMagic = false;
        }
    }

    return matrixIsMagic;
}

console.log(getMatrixMagicStatus([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]
]));

console.log(getMatrixMagicStatus([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]
]));

console.log(getMatrixMagicStatus([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]
]));