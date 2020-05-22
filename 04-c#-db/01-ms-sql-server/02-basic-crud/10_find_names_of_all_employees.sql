SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
FROM [Employees]
WHERE Salary IN (12500, 14000, 23600, 25000)