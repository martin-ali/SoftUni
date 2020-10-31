SELECT
  TOP 10
  s.FirstName,
  s.LastName,
  CONVERT(DECIMAL(18, 2), AVG(se.Grade)) AS [Grade]
FROM
  Students s
  JOIN StudentsExams se ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY [Grade] DESC,
          s.FirstName ASC,
          s.LastName ASC