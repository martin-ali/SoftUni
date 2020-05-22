SELECT
    u.Username,
    c.Name
FROM
    Users u
    JOIN Reports r ON r.UserId = u.Id
    JOIN Categories c ON r.CategoryId = c.Id
WHERE DATEPART(MONTH, r.OpenDate) = DATEPART(MONTH, u.Birthdate) AND DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.Birthdate)
ORDER BY u.Username ASC,
            c.Name ASC