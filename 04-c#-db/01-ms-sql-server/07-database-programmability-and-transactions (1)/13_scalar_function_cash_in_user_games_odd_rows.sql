CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(MAX))
RETURNS TABLE
AS
RETURN
SELECT
    SUM(Cash) AS SumCash
FROM
    (SELECT
        Cash,
        ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNumber
    FROM
        UsersGames
    WHERE GameId = (SELECT Id FROM Games WHERE Name = @gameName)) AS g
WHERE RowNumber % 2 != 0