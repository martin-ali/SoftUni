CREATE TABLE [Logs]
(
    [LogId]     INT   IDENTITY NOT NULL,
    [AccountId] INT   NOT NULL,
    [OldSum]    MONEY,
    [NewSum]    MONEY,

    CONSTRAINT PK_Logs PRIMARY KEY(LogId),
    CONSTRAINT FK_Logs_Accounts FOREIGN KEY(AccountId) REFERENCES Accounts(Id)
)
GO

CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
IF (EXISTS(
SELECT
    *
FROM
    inserted))
BEGIN
    INSERT INTO Logs
        (AccountId, OldSum, NewSum)
    SELECT
        i.Id,
        d.Balance,
        i.Balance
    FROM
        inserted i
        JOIN deleted d
        ON i.Id = d.Id
END
GO

UPDATE Accounts
SET Balance = Balance + 100
WHERE Id = 1