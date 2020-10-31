SELECT
    e.[EmployeeID],
    e.[FirstName],
    (
        CASE
            WHEN datepart(year, p.[StartDate]) < 2005 THEN p.[Name]
            ELSE NULL
        END
    ) AS [ProjectName]
FROM
    [Employees] e
    JOIN [EmployeesProjects] ep
    ON e.[EmployeeID] = ep.[EmployeeID]
    JOIN [Projects] p
    ON ep.[ProjectID] = p.[ProjectID]
WHERE e.[EmployeeID] = 24