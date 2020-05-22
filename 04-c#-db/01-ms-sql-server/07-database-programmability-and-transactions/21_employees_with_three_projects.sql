CREATE PROCEDURE usp_AssignProject(
    @employeeId INT,
    @projectId INT)
AS
BEGIN TRANSACTION

IF ((SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @employeeId) >= 3)
BEGIN
    RAISERROR('The employee has too many projects!', 16, 1)
    ROLLBACK
END

INSERT INTO EmployeesProjects
    (EmployeeID, ProjectId)
VALUES
    (@employeeId, @projectId)

COMMIT