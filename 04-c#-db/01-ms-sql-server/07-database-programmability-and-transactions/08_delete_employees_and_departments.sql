CREATE OR ALTER PROCEDURE usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS

DECLARE @employeeIdsForDeletion TABLE (Id INT)

INSERT INTO @employeeIdsForDeletion
SELECT
    EmployeeID
FROM
    Employees
WHERE DepartmentID = @departmentId

ALTER TABLE Employees
ALTER COLUMN ManagerId INT NULL

ALTER TABLE Departments
ALTER COLUMN ManagerId int NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT
    Id
FROM
    @employeeIdsForDeletion)

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (SELECT
    Id
FROM
    @employeeIdsForDeletion)

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN (SELECT
    Id
FROM
    @employeeIdsForDeletion)

DELETE FROM Employees WHERE DepartmentID = @departmentId
DELETE FROM Departments WHERE DepartmentID = @departmentId

SELECT
    COUNT(*)
FROM
    Employees
WHERE DepartmentID = @departmentId
GO

EXECUTE dbo.usp_DeleteEmployeesFromDepartment 4