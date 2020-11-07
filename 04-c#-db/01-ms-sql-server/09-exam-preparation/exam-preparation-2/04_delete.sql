DELETE st
FROM
    StudentsTeachers st
    JOIN Teachers
t ON t.Id = st.TeacherId
WHERE Phone LIKE '%72%'

DELETE FROM Teachers
WHERE Phone LIKE '%72%'