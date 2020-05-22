SELECT
    Description,
    CONVERT(VARCHAR, OpenDate, 105)
FROM
    Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate ASC,
            Description ASC