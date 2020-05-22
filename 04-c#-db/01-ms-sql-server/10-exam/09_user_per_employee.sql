SELECT
    CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
    COUNT(DISTINCT(r.UserId)) AS UsersCount
FROM
    Employees e
    LEFT JOIN Reports r ON r.EmployeeId = e.Id
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY COUNT(DISTINCT(r.UserId)) DESC,
            FullName ASC