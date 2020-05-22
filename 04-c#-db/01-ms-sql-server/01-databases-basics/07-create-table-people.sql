CREATE TABLE People
(
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(200) NOT NULL,
    [ProfilePicture] VARBINARY(MAX),
    [Height] REAL,
    [Weight] REAL,
    [Gender] CHAR(1) NOT NULL CHECK(Gender = 'm' OR Gender = 'f'),
    [Birthdate] DATETIME NOT NULL,
    [Biography] NVARCHAR(MAX)
)

ALTER TABLE [People]
ADD CONSTRAINT CHK_Picture CHECK(Datalength(ProfilePicture) <= (2 * 1024 * 1024))

INSERT INTO People
    ([Name], [Gender], [Birthdate])
VALUES
    ('SomeName1', 'm', GETDATE()),
    ('SomeName2', 'f', GETDATE()),
    ('SomeName3', 'm', GETDATE()),
    ('SomeName4', 'f', GETDATE()),
    ('SomeName5', 'm', GETDATE())