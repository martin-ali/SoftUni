CREATE TABLE [Categories]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [CategoryName] NVARCHAR(30) NOT NULL,
    [DailyRate] REAL NOT NULL,
    [WeeklyRate] REAL NOT NULL,
    [MonthlyRate] REAL NOT NULL,
    [WeekendRate] REAL NOT NULL
)

CREATE TABLE [Cars]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [PlateNumber] CHAR(8) NOT NULL,
    [Manufacturer] NVARCHAR(20) NOT NULL,
    [Model] NVARCHAR(20) NOT NULL,
    [CarYear] DATETIME,
    [CategoryId] INT FOREIGN KEY REFERENCES categories(Id) NOT NULL,
    [Doors] INT NOT NULL CHECK (2 <= Doors AND Doors <= 4),
    [Picture] VARBINARY(MAX),
    [Condition] NVARCHAR(10) NOT NULL CHECK(Condition = 'Good' OR Condition = 'Bad'),
    [Available] BIT NOT NULL DEFAULT 0
)

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
    [DriverLicenseNumber] CHAR(10) NOT NULL,
    [FullName] NVARCHAR(40) NOT NULL,
    [Address] NVARCHAR(100),
    [City] NVARCHAR(20),
    [ZipCode] CHAR(4),
    [Notes] NVARCHAR(MAX)
)

CREATE TABLE [RentalOrders]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
    [CustomerId] INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
    [CarId] INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
    [TankLevel] INT,
    [KilometrageStart] INT NOT NULL,
    [KilometrageEnd] INT NOT NULL,
    [TotalKilometrage] INT,
    [StartDate] DATETIME NOT NULL,
    [EndDate] DATETIME NOT NULL,
    [TotalDays] INT,
    [RateApplied] REAL NOT NULL,
    [TaxRate] REAL NOT NULL,
    [OrderStatus] NVARCHAR(10) CHECK(OrderStatus = 'Completed' OR OrderStatus = 'Working'),
    [Notes] NVARCHAR(MAX)
)

INSERT INTO [Categories]
    (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
    ('Category1', 1, 6, 20, 1),
    ('Category2', 10, 60, 200, 10),
    ('Category3', 100, 600, 2000, 100)

INSERT INTO [Cars]
    (PlateNumber, Manufacturer, Model, CategoryId, Doors, Condition, Available)
VALUES
    ('12345678', 'Manufacturer1', 'Model1', 1, 2, 'Good', 1),
    ('12345178', 'Manufacturer2', 'Model2', 2, 4, 'Good', 0),
    ('12345378', 'Manufacturer3', 'Model3', 3, 4, 'Bad', 1)

INSERT INTO [Employees]
    (FirstName,LastName,Title)
VALUES
    ('Name1', 'Last1', 'Salesman'),
    ('Name2', 'Last2', 'Salesman'),
    ('Name3', 'Last3', 'Manager')

INSERT INTO [Customers]
    (DriverLicenseNumber,FullName)
VALUES
    ('1234567890', 'Named1'),
    ('1234562890', 'Named2'),
    ('1234563890', 'Named3')

INSERT INTO [RentalOrders]
    (EmployeeId, CustomerId, CarId, KilometrageStart, KilometrageEnd, StartDate, EndDate, RateApplied, TaxRate, OrderStatus)
VALUES
    (1, 1, 1, 1200, 12298, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 10, 2, 'Completed'),
    (2, 1, 3, 3242, 122298, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 100, 21, 'Working'),
    (3, 2, 2, 12200, 222222, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 831, 33, 'Completed')