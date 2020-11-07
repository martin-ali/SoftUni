function crossMatrix(input)
{
    function victoryAchieved(dashboard, player)
    {
        // Horizontal victory check
        for (let row = 0; row < dashboard.length; ++row)
        {
            if (dashboard[row].every(c => c === player.mark))
            {
                return true;
            }
        }

        // Vertical victory check
        for (let col = 0; col < dashboard.length; ++col)
        {
            let gameIsWon = true;
            for (let row = 0; row < dashboard.length; ++row)
            {
                if (dashboard[row][col] !== player.mark)
                {
                    gameIsWon = false;
                    break
                }
            }

            if (gameIsWon)
            {
                return true;
            }
        }

        let gameIsWon = true;
        // Diagonal up/left -> down/right victory check
        for (let row = 0, col = 0; row < dashboard.length && col < dashboard.length; ++row, ++col)
        {
            if (dashboard[row][col] !== player.mark)
            {
                gameIsWon = false;
                break;
            }
        }

        if (gameIsWon)
        {
            return true;
        }

        // Diagonal up/right -> down/left victory check
        for (let row = 0, col = dashboard.length - 1; row < dashboard.length && col >= 0; ++row, --col)
        {
            if (dashboard[col][row] !== player.mark)
            {
                gameIsWon = false;
                break;
            }
        }

        if (gameIsWon)
        {
            return true;
        }

        return false;
    }

    function positionIsTaken(dashboard, move)
    {
        if (dashboard[move.row][move.col] !== 'false')
        {
            return true;
        }

        return false;
    }

    function printDashboard(dashboard)
    {
        for (const row of dashboard)
        {
            console.log(row.join('\t'));
        }
    }

    function dashboardHasFreeSpaces(dashboard)
    {
        return dashboard.some(r => r.includes('false'));
    }

    const dashboard = [['false', 'false', 'false'], ['false', 'false', 'false'], ['false', 'false', 'false']];
    const moves = input.map(m =>
    {
        const [row, col] = m.split(' ');

        return { row, col };
    });

    const firstPlayer = { mark: 'X' };
    const secondPlayer = { mark: 'O' };

    let [currentPlayer, nextPlayer] = [firstPlayer, secondPlayer];

    let gameIsWon = false;
    while (moves.length !== 0 && dashboardHasFreeSpaces(dashboard))
    {
        const move = moves.shift();

        if (positionIsTaken(dashboard, move))
        {
            console.log('This place is already taken. Please choose another!');
            continue;
        }

        dashboard[move.row][move.col] = currentPlayer.mark;

        if (victoryAchieved(dashboard, currentPlayer))
        {
            gameIsWon = true;
            break;
        }

		[currentPlayer, nextPlayer] = [nextPlayer, currentPlayer];
    }

    if (gameIsWon)
    {
        console.log(`Player ${currentPlayer.mark} wins!`);
    }
    else if (dashboardHasFreeSpaces(dashboard) === false)
    {
        console.log('The game ended! Nobody wins :(');
    }

    printDashboard(dashboard);
}

crossMatrix(['0 1', '0 0', '0 2', '2 0', '1 0', '1 1', '1 2', '2 2', '2 1', '0 0']);
// crossMatrix(['0 0', '0 0', '1 1', '0 1', '1 2', '0 2', '2 2', '1 2', '2 2', '2 1']);
// crossMatrix(['0 1', '0 0', '0 2', '2 0', '1 0', '1 2', '1 1', '2 1', '2 2', '0 0']);