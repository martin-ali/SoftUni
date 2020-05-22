SELECT
    TOP (3)
    e.[EmployeeID],
    e.[FirstName]
FROM
    [Employees] e
WHERE e.[EmployeeID] NOT IN
(
    SELECT
        p.[EmployeeID]
    FROM
        [EmployeesProjects] p
)
ORDER BY [EmployeeID] ASC