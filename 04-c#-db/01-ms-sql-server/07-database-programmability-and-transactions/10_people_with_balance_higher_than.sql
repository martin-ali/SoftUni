CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@balance DECIMAL(18, 4))
AS
SELECT
    FirstName,
    LastName
FROM
    Accounts a
    JOIN AccountHolders ah
    ON a.AccountHolderId = ah.Id
GROUP BY ah.FirstName, ah.LastName
HAVING SUM(Balance) > @balance
ORDER BY ah.FirstName, ah.LastName