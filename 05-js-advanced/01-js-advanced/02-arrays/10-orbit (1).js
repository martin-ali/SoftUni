function createAndPrintMatrix([cols, rows, starRow, starCol])
{
    function printMatrix(matrix)
    {
        for (const row of matrix)
        {
            console.log(row.join(' '));
        }
    }

    const matrix = [];

    for (let row = 0; row < rows; ++row)
    {
        matrix.push([]);
        for (let col = 0; col < cols; ++col)
        {
            const value = Math.max(Math.abs(row - starRow), Math.abs(col - starCol)) + 1;
            matrix[row].push(value);
        }
    }

    printMatrix(matrix);
}