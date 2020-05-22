CREATE PROCEDURE usp_AssignEmployeeToReport(
    @EmployeeId INT,
    @ReportId INT)
AS
DECLARE @employeeDepartmentId INT =
(SELECT
    DepartmentId
FROM
    Employees
WHERE Id = @EmployeeId)

DECLARE @reportCategoryDepartmentId INT =
(SELECT
    c.DepartmentId
FROM
    Reports r
    JOIN Categories c ON c.Id = r.CategoryId
WHERE r.Id = @ReportId)

IF (@employeeDepartmentId != @reportCategoryDepartmentId) RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)

UPDATE Reports
SET EmployeeId = @EmployeeId
WHERE Id = @ReportId
GO

EXEC usp_AssignEmployeeToReport 30, 1
GO

EXEC usp_AssignEmployeeToReport 17, 2
GOb