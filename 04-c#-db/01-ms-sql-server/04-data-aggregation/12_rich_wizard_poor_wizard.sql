SELECT SUM([DepositAmount] - [NextDepositAmount]) AS [Diff]
FROM (SELECT [FirstName],
        [DepositAmount],
        LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS [NextDepositAmount]
    FROM [WizzardDeposits]) AS diffTable

-- SELECT Sum([DepositAmount] - [NextDepositAmount])
-- FROM (SELECT currentDeposits.[Id],
--         currentDeposits.[FirstName],
--         currentDeposits.[DepositAmount],
--         (SELECT nextDeposits.DepositAmount
--         FROM WizzardDeposits AS nextDeposits
--         WHERE nextDeposits.Id = currentDeposits.Id + 1) AS [NextDepositAmount]
--     FROM [WizzardDeposits] AS currentDeposits) AS perryThePlatypus