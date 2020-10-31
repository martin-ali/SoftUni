SELECT
    e.[EmployeeID],
    e.[FirstName],
    e.[LastName],
    d.[Name] AS [DepartmentName]
FROM
    [Employees] e
    JOIN [Departments] d
    ON e.[DepartmentID] = d.[DepartmentID]
        AND d.[Name] = 'Sales'
ORDER BY e.[EmployeeID] ASC