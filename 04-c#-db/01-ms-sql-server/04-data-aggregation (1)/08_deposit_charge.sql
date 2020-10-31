SELECT [DepositGroup], [MagicWandCreator], min(DepositCharge) AS [MinDepositCharge]
FROM [WizzardDeposits]
GROUP BY [DepositGroup], [MagicWandCreator]
ORDER BY [MagicWandCreator] ASC, [DepositGroup] ASC