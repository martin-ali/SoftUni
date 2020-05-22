CREATE TABLE [Employees]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [FirstName] NVARCHAR(20) NOT NULL,
    [LastName] NVARCHAR(20) NOT NULL,
    [Title] NVARCHAR(30) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

CREATE TABLE [Customers]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [AccountNumber] CHAR(10) NOT NULL,
    [FirstName] NVARCHAR(20) NOT NULL,
    [LastName] NVARCHAR(20) NOT NULL,
    [PhoneNumber] CHAR(10),
    [EmergencyName] NVARCHAR(20),
    [EmergencyNumber] CHAR(10),
    [Notes] NVARCHAR(MAX)
)

CREATE TABLE [RoomStatus]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [RoomStatus] NVARCHAR(10) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

CREATE TABLE [RoomTypes]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [RoomType] NVARCHAR(10) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

CREATE TABLE [BedTypes]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [BedType] NVARCHAR(10) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

CREATE TABLE [Rooms]
(
    [RoomNumber] INT PRIMARY KEY IDENTITY(1, 1),
    [RoomType] INT FOREIGN KEY REFERENCES RoomTypes(Id) NOT NULL,
    [BedType] INT FOREIGN KEY REFERENCES BedTypes(Id) NOT NULL,
    [Rate] REAL NOT NULL,
    [RoomStatus] INT FOREIGN KEY REFERENCES RoomStatus(Id) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

CREATE TABLE [Payments]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
    [PaymentDate] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    [AccountNumber] CHAR(10)NOT NULL,
    [FirstDateOccupied] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    [LastDateOccupied] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    [TotalDays] INT,
    [AmountCharged] REAL,
    [TaxRate] REAL NOT NULL,
    [TaxAmount] REAL,
    [PaymentTotal] REAL,
    [Notes] NVARCHAR(MAX)
)

CREATE TABLE [Occupancies]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
    [DateOccupied] DATETIME NOT NULL,
    [AccountNumber]CHAR(10) NOT NULL,
    [RoomNumber] INT FOREIGN KEY REFERENCES [Rooms](RoomNumber),
    [RateApplied] REAL NOT NULL,
    [PhoneCharge] REAL NOT NULL DEFAULT 0,
    [NOTES] NVARCHAR (MAX)
)

INSERT INTO [Employees]
    (FirstName, LastName, Title)
VALUES
    ('Name1', 'Last1', 'Emp1'),
    ('Name2', 'Last2', 'Emp2'),
    ('Name3', 'Last3', 'Emp3')

INSERT INTO [Customers]
    (AccountNumber, FirstName, LastName, PhoneNumber)
VALUES
    ('123456790', 'Name1', 'Last1', '1234567890'),
    ('223456790', 'Name2', 'Last2', '2234567890'),
    ('323456790', 'Name3', 'Last3', '3234567890')

INSERT INTO [RoomStatus]
    (RoomStatus)
VALUES
    ('Occupied'),
    ('Empty'),
    ('Dirty')

INSERT INTO [BedTypes]
    (BedType)
VALUES
    ('Small'),
    ('Big'),
    ('Huge')

INSERT INTO [RoomTypes]
    (RoomType)
VALUES
    ('Small'),
    ('Big'),
    ('Huge')

INSERT INTO [Rooms]
    (RoomType, BedType, Rate, RoomStatus)
VALUES
    (2, 1, 10, 1),
    (3, 1, 10, 1),
    (1, 1, 10, 1)

INSERT INTO [Payments]
    (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TaxRate)
VALUES
    (1, 23, 3, '01-01-2019', '04-01-2019', 25),
    (1, 323, 2, '01-02-2019', '04-05-2019', 35),
    (3, 3, 1, '01-03-2019', '04-03-2019', 45)

INSERT INTO [Occupancies]
    (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied)
VALUES
    (1, '01-01-2019', '1234567890', 1, 10),
    (2, '01-01-2019', '1234567890', 1, 10),
    (3, '01-01-2019', '1234567890', 1, 10)