SELECT
    Description,
    c.Name
FROM
    Reports r
    JOIN Categories c ON c.Id = r.CategoryId
ORDER BY Description ASC,
            c.Name ASC