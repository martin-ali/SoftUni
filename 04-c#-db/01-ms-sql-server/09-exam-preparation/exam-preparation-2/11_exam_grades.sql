CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(20, 2))
returns NVARCHAR(100)
AS
BEGIN
    IF (@grade > 6)
    BEGIN
        RETURN 'Grade cannot be above 6.00!'
    END

    IF (NOT EXISTS(SELECT
        *
    FROM
        Students
    WHERE Id = @studentId))
    BEGIN
        RETURN 'The student with provided id does not exist in the school!'
    END

    DECLARE @gradeCeiling DECIMAL(20, 2) = @grade + 0.50

    DECLARE @gradeCount INT = (
    SELECT
        COUNT(*)
    FROM
        StudentsExams
    WHERE StudentId = @studentId
        AND Grade BETWEEN @grade AND @gradeCeiling)

    RETURN CONCAT('You have to update ', @gradeCount,' grades for the student ', (
    SELECT
        FirstName
    FROM
        Students
    WHERE Id = @studentId))
END