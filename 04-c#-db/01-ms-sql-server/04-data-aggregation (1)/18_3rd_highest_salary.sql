SELECT
    DISTINCT
    [DepartmentID],
    [Salary]
FROM(SELECT
        [DepartmentId],
        [Salary],
        DENSE_RANK() OVER (PARTITION BY [DepartmentId] ORDER BY [Salary] DESC) AS [Rank]
    FROM
        [Employees]) AS e
WHERE [RANK] = 3