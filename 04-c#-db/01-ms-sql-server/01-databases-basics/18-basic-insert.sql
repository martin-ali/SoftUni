USE [SoftUni]

INSERT INTO [Towns]
    (Name)
VALUES
    ('Sofia'),
    ('Plovdiv'),
    ('Varna'),
    ('Burgas')

INSERT INTO [Departments]
    (Name)
VALUES
    ('Engineering'),
    ('Sales'),
    ('Marketing'),
    ('Software Development'),
    ('Quality Assurance')

INSERT INTO [Employees]
    (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES
    ('Name1', 'Mid1', 'Last1', 'Pro-gamer', 1, '01-01-2019', 14000),
    ('Name2', 'Mid2', 'Last2', 'Pro', 2, '01-02-2019', 1000),
    ('Name3', 'Mid3', 'Last3', 'Gamer', 3, '01-03-2019', 11200)