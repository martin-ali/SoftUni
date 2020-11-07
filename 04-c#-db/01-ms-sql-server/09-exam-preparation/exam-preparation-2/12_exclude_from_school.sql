CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
IF (NOT EXISTS(SELECT
    *
FROM
    Students
WHERE Id = @StudentId))
BEGIN
    RAISERROR('This school has no student with the provided id!', 16, 1)
END

DELETE FROM StudentsTeachers
WHERE StudentId = @StudentId

DELETE FROM StudentsExams
WHERE StudentId = @StudentId

DELETE FROM StudentsSubjects
WHERE StudentId = @StudentId

DELETE FROM Students
WHERE Id = @StudentId