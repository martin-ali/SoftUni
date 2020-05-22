SELECT
    e.[FirstName],
    e.[LastName],
    e.[HireDate],
    d.[Name] AS [DeptName]
FROM
    [Employees] e
    JOIN [Departments] d
    ON e.[DepartmentID] = d.[DepartmentID]
        AND d.[Name] IN ('Sales', 'Finance')
WHERE e.[HireDate] > '1.1.1999'
ORDER BY e.[HireDate] ASC