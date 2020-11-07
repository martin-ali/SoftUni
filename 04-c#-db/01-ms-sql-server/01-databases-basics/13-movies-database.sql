CREATE TABLE [Directors]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [DirectorName] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

CREATE TABLE [Genres]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [GenreName] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

CREATE TABLE [Categories]
(

    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [CategoryName] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

CREATE TABLE [Movies]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Title] NVARCHAR(50) NOT NULL,
    [DirectorId] INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
    [CopyrightYear] DATETIME NOT NULL,
    [Length] INT NOT NULL,
    [GenreId] INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
    [CategoryId] INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
    [Rating] INT NOT NULL CHECK (0 <= Rating AND Rating <= 10),
    [Notes] NVARCHAR(MAX)
)

INSERT INTO [Directors]
    (DirectorName, Notes)
VALUES
    ('Pesho', 'Pravec'),
    ('Gosho', ''),
    ('Stamat', ''),
    ('Jorgen', ''),
    ('Maria', 'Dis be da hit')

INSERT INTO [Genres]
    (GenreName, Notes)
VALUES
    ('Action', ''),
    ('Horror', ''),
    ('Comedy', 'Har'),
    ('Sci-Fi', ''),
    ('Thriller', 'Ze')

INSERT INTO [Categories]
    (CategoryName, Notes)
VALUES
    ('Funny', 'Wow, so hilarious, yo!'),
    ('Random', ''),
    ('Silly', ''),
    ('Exciting', ''),
    ('Stupid', '')

INSERT INTO [Movies]
    (Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
VALUES
    ('The grape depression', 5, CURRENT_TIMESTAMP, 93, 1, 2, 9, 'Wow, this zer gut'),
    ('Saving private Nasakoto Yakata', 2, CURRENT_TIMESTAMP, 65, 3, 5, 10, 'Wow, this kawaii'),
    ('The dogfather', 3, CURRENT_TIMESTAMP, 65, 3, 1, 4, 'Y so lo tho'),
    ('Judge Gregg', 1, CURRENT_TIMESTAMP, 85, 2, 4, 10, 'Wow, so bark'),
    ('Olympic', 3, CURRENT_TIMESTAMP, 65, 4, 4, 10, 'So dramatic')