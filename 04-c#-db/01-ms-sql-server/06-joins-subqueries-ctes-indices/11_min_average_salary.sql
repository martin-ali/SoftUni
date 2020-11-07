SELECT
    MIN(AverageSalary) AS [MinAverageSalary]
FROM
(
    SELECT
        Avg([Salary]) AS [AverageSalary]
    FROM
        [Employees]
    GROUP BY [DepartmentID]
) AS s