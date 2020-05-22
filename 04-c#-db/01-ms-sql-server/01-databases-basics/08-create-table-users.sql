CREATE TABLE [Users]
(
    [Id] BIGINT IDENTITY,
    [Username] VARCHAR(30) NOT NULL UNIQUE,
    [Password] VARCHAR(26) NOT NULL,
    [ProfilePicture] VARBINARY(MAX),
    [LastLoginTime] DATETIME DEFAULT CURRENT_TIMESTAMP,
    [IsDeleted] BIT DEFAULT 0
)

ALTER TABLE [Users]
ADD CONSTRAINT PK_Minions_Users PRIMARY KEY (Id)

ALTER TABLE [Users]
ADD CONSTRAINT CHK_ProfilePicture CHECK(Datalength(ProfilePicture) <= (900 * 1024))

INSERT INTO [Users]
    ([Username],[Password])
VALUES
    ('User1', 'Password1'),
    ('User2', 'Password2'),
    ('User3', 'Password3'),
    ('User4', 'Password4'),
    ('User5', 'Password5')