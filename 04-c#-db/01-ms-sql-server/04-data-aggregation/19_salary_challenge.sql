SELECT TOP 10
    e.[FirstName], e.[LastName], e.[DepartmentID]
FROM [Employees] e
WHERE [Salary] > (SELECT AVG(x.Salary)
FROM [Employees] x
WHERE [DepartmentID] = e.[DepartmentID])
ORDER BY [DepartmentID]