SELECT [ProductName],
    [OrderDate],
    DATEADD(DAY, 3, [OrderDate]) AS [Pay Date],
    DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Date]
FROM [Orders]