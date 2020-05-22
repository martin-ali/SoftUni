SELECT
    s.Name,
    AVG(st.Grade)
FROM
    StudentsSubjects st
    JOIN Subjects s ON s.Id = st.SubjectId
GROUP BY s.Name, s.Id
ORDER BY s.Id ASC