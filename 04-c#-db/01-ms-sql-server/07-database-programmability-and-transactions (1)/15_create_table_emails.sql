CREATE TABLE [NotificationEmails]
(
    Id        INT          IDENTITY NOT NULL,
    Recipient INT          NOT NULL,
    Subject   VARCHAR(100) NOT NULL,
    Body      VARCHAR(MAX) NOT NULL,

    CONSTRAINT PK_NotificationEmails PRIMARY KEY(Id),
    CONSTRAINT FK_NotificationEmails_AccountHolders FOREIGN KEY(Recipient) REFERENCES AccountHolders(Id)
)
GO

CREATE TRIGGER tr_LogsUpdate ON [Logs] FOR INSERT
AS
IF (EXISTS(
SELECT
    *
FROM
    inserted))
BEGIN
    INSERT INTO NotificationEmails
        (Recipient, Subject, Body)
    SELECT
        AccountId,
        CONCAT('Balance change for account: ', AccountId),
        CONCAT('On ', CONVERT (VARCHAR, getdate (), 0) , ' your balance was changed from ', OldSum, ' to ', NewSum)
    FROM
        inserted
END
GO

UPDATE Accounts
SET Balance = Balance + 100
WHERE Id = 1
GO

UPDATE Accounts
SET Balance = Balance + 222
WHERE Id = 2
GO

UPDATE Accounts
SET Balance = Balance + 321
WHERE Id = 3
GO