function printSpiralMatrix(rows, cols)
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
            matrix[row].push(0);
        }
    }

    let row = 0;
    let col = 0;
    let currentNumber = 2;
    let directions = ['right', 'down', 'left', 'up'];
    let getCoordinatesModifierByDirection = {
        right: [0, 1],
        down: [1, 0],
        left: [0, -1],
        up: [-1, 0]
    };

    matrix[0][0] = 1;
    while (currentNumber <= rows * cols)
    {
        const currentDirection = directions.shift();
        const [rowModifier, colModifier] = getCoordinatesModifierByDirection[currentDirection];

        while (true)
        {
            row += rowModifier;
            col += colModifier;

            const inBounds = 0 <= row && row < rows && 0 <= col && col < cols;
            if (inBounds === false
                || matrix[row][col] !== 0)
            {
                row -= rowModifier;
                col -= colModifier;
                break;
            }

            matrix[row][col] = currentNumber++;
        }

        directions.push(currentDirection);
    }

    printMatrix(matrix);
}

// printSpiralMatrix(5, 5);
// printSpiralMatrix(3, 3);