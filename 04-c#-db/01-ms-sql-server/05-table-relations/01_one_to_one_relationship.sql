CREATE TABLE [Passports]
(
    [PassportID] INT IDENTITY(101, 1) NOT NULL,
    [PassportNumber] CHAR(8) NOT NULL,

    CONSTRAINT PK_Passports PRIMARY KEY(PassportID)
)

CREATE TABLE [Persons]
(
    [PersonID] INT IDENTITY NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL,
    [Salary] REAL,
    [PassportID] INT UNIQUE NOT NULL,

    CONSTRAINT PK_Persons PRIMARY KEY(PersonID),
    CONSTRAINT FK_Persons_Passports FOREIGN KEY(PassportID) REFERENCES Passports(PassportID)
)

INSERT INTO [Passports]
VALUES
    ('N34FG21B'),
    ('K65LO4R7'),
    ('ZE657QP2')

INSERT INTO [Persons]
VALUES
    ('Roberto', 43300.00, 102),
    ('Tom', 56100.00, 103),
    ('Yana', 60200.00, 101)