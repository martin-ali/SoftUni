SELECT
    CASE
    WHEN e.FirstName IS NULL THEN 'None'
    ELSE CONCAT(e.FirstName, ' ', e.LastName)
    END AS Employee,
    CASE
    WHEN e.FirstName IS NULL THEN 'None'
    ELSE d.Name END AS Department,
    c.Name,
    r.Description,
    CONVERT(VARCHAR, r.OpenDate, 104) AS OpenDate,
    s.Label,
    u.Name
FROM
    Reports r
    LEFT JOIN Employees e ON e.Id = r.EmployeeId
    LEFT JOIN Departments d ON d.Id = e.DepartmentId
    LEFT JOIN Categories c ON c.Id = r.CategoryId
    LEFT JOIN Status s ON s.Id = r.StatusId
    LEFT JOIN Users u ON u.Id = r.UserId
ORDER BY e.FirstName DESC,
            e.LastName DESC,
            d.Name ASC,
            c.Name ASC,
            r.Description ASC,
            r.OpenDate ASC,
            s.Label ASC,
            u.Name ASC