CREATE PROCEDURE usp_TransferMoney(
    @senderId INT,
    @receiverId INT,
    @amount DECIMAL(18, 4))
AS
BEGIN TRANSACTION

IF (@amount <= 0)
BEGIN
    ROLLBACK
    RAISERROR('Money cannot be negative', 16, 50000)
END

EXECUTE dbo.usp_WithdrawMoney @senderId, @amount
EXECUTE dbo.usp_DepositMoney @receiverId, @amount

COMMIT