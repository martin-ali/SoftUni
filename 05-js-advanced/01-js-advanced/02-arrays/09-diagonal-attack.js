function crossMatrix(inputMatrix)
{
    function printMatrix(matrix)
    {
        for (const row of matrix)
        {
            console.log(row.join(' '));
        }
    }

    function fillMatrix(matrix, value, size)
    {
        // console.log(matrix);
        for (let row = 0; row < size; ++row)
        {
            matrix.push([]);
            for (let col = 0; col < size; ++col)
            {
                matrix[row].push(value);
            }
        }
        // console.log(matrix);
    }

    function fillMatrixDiagonals(sourceMatrix, destinationMatrix)
    {
        for (let row = 0, col = 0; row < sourceMatrix.length && col < sourceMatrix.length; ++row, ++col)
        {
            destinationMatrix[row][col] = sourceMatrix[row][col];
        }

        for (let row = 0, col = sourceMatrix.length - 1; row < sourceMatrix.length && col >= 0; ++row, --col)
        {
            destinationMatrix[row][col] = sourceMatrix[row][col];
        }
    }

    const matrix = [];

    // Fill matrix
    for (const rowData of inputMatrix)
    {
        const row = rowData.split(' ').map(n => parseInt(n, 10));

        matrix.push(row);
    }

    // Get sum of u/l-d/r diagonal
    let firstDiagonalSum = 0;
    for (let row = 0, col = 0; row < matrix.length && col < matrix.length; ++row, ++col)
    {
        firstDiagonalSum += matrix[row][col];
    }

    // Get sum of u/r-d/l diagonal
    let secondDiagonalSum = 0;
    for (let row = 0, col = matrix.length - 1; row < matrix.length && col >= 0; ++row, --col)
    {
        secondDiagonalSum += matrix[row][col];
    }

    if (firstDiagonalSum === secondDiagonalSum)
    {
        const diagonalSum = firstDiagonalSum;
        const result = [];

        fillMatrix(result, diagonalSum, matrix.length);

        fillMatrixDiagonals(matrix, result);

        printMatrix(result);
    }
    else
    {
        printMatrix(matrix);
    }
}