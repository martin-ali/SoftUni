SELECT
  CONCAT(FirstName, ' ', LastName) AS [Full Name]
FROM
  Students
WHERE
  Id NOT IN (
    SELECT
  StudentId
FROM
  StudentsExams
  )
ORDER BY
  [Full Name]