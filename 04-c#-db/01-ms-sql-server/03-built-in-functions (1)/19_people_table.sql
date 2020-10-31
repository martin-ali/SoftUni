CREATE TABLE [People]
(
    [Id] INT IDENTITY,
    [Name] NVARCHAR(20) NOT NULL,
    [Birthdate] DATETIME NOT NULL,

    CONSTRAINT PK_People PRIMARY KEY(Id)
)
GO

INSERT INTO [People]
    ([Name], [Birthdate])
VALUES
    ('Person1', '12/12/2019'),
    ('Person2', '10/10/1919'),
    ('Person3', '11/12/1987'),
    ('Person4', '12/12/2006'),
    ('Person5', '07/11/1965'),
    ('Person6', '06/12/2019'),
    ('Person7', '12/12/1972'),
    ('Person8', '01/12/1929')
GO

SELECT [Name],
    FORmat([Birthdate], 'yyyy-MM-dd') AS [Birthdate],
    DATEDIFF(YEAR, [Birthdate], CURRENT_TIMESTAMP) AS [Age in Years],
    DATEDIFF(MONTH, [Birthdate], CURRENT_TIMESTAMP) AS [Age in Months],
    DATEDIFF(DAY, [Birthdate], CURRENT_TIMESTAMP) AS [Age in Days],
    DATEDIFF(MINUTE, [Birthdate], CURRENT_TIMESTAMP) AS [Age in Minutes]
FROM [People]