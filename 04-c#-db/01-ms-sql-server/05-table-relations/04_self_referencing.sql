CREATE TABLE Teachers
(
    [TeacherID] INT IDENTITY NOT NULL,
    [Name] NVARCHAR(30) NOT NULL,
    [ManagerID] INT,

    CONSTRAINT PK_Teachers PRIMARY KEY(TeacherID),
    CONSTRAINT FK_Teachers_ManagerID FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
)
