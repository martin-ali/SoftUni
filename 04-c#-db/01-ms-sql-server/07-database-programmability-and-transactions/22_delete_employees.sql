CREATE TABLE Deleted_Employees
(
    EmployeeId   INT            NOT NULL IDENTITY,
    FirstName    VARCHAR(100)   NOT NULL,
    LastName     VARCHAR(100)   NOT NULL,
    MiddleName   VARCHAR(100),
    JobTitle     VARCHAR(100)   NOT NULL,
    DepartmentId INT            NOT NULL,
    Salary       DECIMAL(18, 4) NOT NULL,

    CONSTRAINT PK_Deleted_Employees PRIMARY KEY(EmployeeId)
)
GO

-- FOR also means AFTER
CREATE TRIGGER tr_EmployeesDelete ON Employees FOR DELETE
AS
IF (EXISTS(
SELECT
    *
FROM
    deleted))
BEGIN
    INSERT INTO Deleted_Employees
        (FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
    SELECT
        FirstName,
        LastName,
        MiddleName,
        JobTitle,
        DepartmentID,
        Salary
    FROM
        deleted
END
GO

DELETE FROM Employees