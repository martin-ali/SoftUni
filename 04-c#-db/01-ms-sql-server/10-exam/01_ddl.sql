CREATE DATABASE Service
GO

USE Service

CREATE TABLE Users
(
    Id        INT         IDENTITY,
    Username  VARCHAR(30) NOT NULL,
    Password  VARCHAR(50) NOT NULL,
    Name      VARCHAR(50),
    Birthdate DATETIME,
    Age       INT,
    Email     VARCHAR(50) NOT NULL,

    CONSTRAINT PK_Users PRIMARY KEY(Id)
)

CREATE TABLE Departments
(
    Id   INT         IDENTITY,
    Name VARCHAR(50) NOT NULL,

    CONSTRAINT PK_Departments PRIMARY KEY(Id)
)

CREATE TABLE Employees
(
    Id           INT         IDENTITY,
    FirstName    VARCHAR(25),
    LastName     VARCHAR(25),
    Birthdate    DATETIME,
    Age          INT        ,
    DepartmentId INT,

    CONSTRAINT PK_Employees PRIMARY KEY(Id),
    CONSTRAINT FK_Employees_Departments FOREIGN KEY(DepartmentId) REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
    Id           INT         IDENTITY,
    Name         VARCHAR(50) NOT NULL,
    DepartmentId INT         NOT NULL,

    CONSTRAINT PK_Categories PRIMARY KEY(Id),
    CONSTRAINT FK_Categories_Departments FOREIGN KEY(DepartmentId) REFERENCES Departments(Id)
)

CREATE TABLE Status
(
    Id    INT         IDENTITY,
    Label VARCHAR(30) NOT NULL,

    CONSTRAINT PK_Status PRIMARY KEY(Id)
)

CREATE TABLE Reports
(
    Id          INT          IDENTITY,
    CategoryId  INT          NOT NULL,
    StatusId    INT          NOT NULL,
    OpenDate    DATETIME     NOT NULL,
    CloseDate   DATETIME,
    Description VARCHAR(200) NOT NULL,
    UserId      INT          NOT NULL,
    EmployeeId  INT,

    CONSTRAINT PK_Reports PRIMARY KEY(Id),
    CONSTRAINT FK_Reports_Categories FOREIGN KEY(CategoryId) REFERENCES Categories(Id),
    CONSTRAINT FK_Reports_StatusId FOREIGN KEY(StatusId) REFERENCES Status(Id),
    CONSTRAINT FK_Reports_Users FOREIGN KEY(UserId) REFERENCES Users(Id),
    CONSTRAINT FK_Reports_Employees FOREIGN KEY(EmployeeId) REFERENCES Employees(Id)
)