SELECT *
INTO EmployeesWithHighSalaries
FROM [Employees]
WHERE [Salary] > 30000

DELETE FROM [EmployeesWithHighSalaries] WHERE [ManagerID] = 42

UPDATE [EmployeesWithHighSalaries]
SET [Salary] += 5000
WHERE [DepartmentID] = 1

SELECT [DepartmentID], AVG(Salary) AS [AverageSalary]
FROM [EmployeesWithHighSalaries]
GROUP BY [DepartmentID]