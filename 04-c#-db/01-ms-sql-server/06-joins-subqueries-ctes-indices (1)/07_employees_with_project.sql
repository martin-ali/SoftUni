SELECT
    TOP (5)
    e.[EmployeeID],
    e.[FirstName],
    p.[Name] AS [ProjectName]
FROM
    [Employees] e
    JOIN [EmployeesProjects] ep
    ON e.[EmployeeID] = ep.[EmployeeID]
    JOIN [Projects] p
    ON ep.[ProjectID] = p.[ProjectID]
        AND p.[StartDate] > CONVERT(SMALLDATETIME, '12.08.2002')
        AND p.[EndDate] IS NULL
ORDER BY e.[EmployeeID] ASC