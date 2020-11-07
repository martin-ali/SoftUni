SELECT
    REPLACE(CONCAT(FirstName, ' ', MiddleName, ' ', LastName), '  ', ' ') AS [Full Name]
FROM
    Students
WHERE Id NOT IN (
SELECT
    StudentId
FROM
    StudentsSubjects)
ORDER BY [Full Name] ASC