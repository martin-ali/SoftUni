-- 0
--CREATE FUNCTION ufn_CashInUsersGames(@GameName VARCHAR(MAX))
--RETURNS @RtnTable TABLE
--(
--SumCash MONEY
--)
--AS
--	BEGIN
--	DECLARE @CashSum MONEY

--	SET @CashSum =  (SELECT SUM(ug.Cash) AS 'SumCash'
--	FROM (
--			SELECT Cash, GameId, ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RoWNum
--			FROM UsersGames
--			WHERE GameId = (SELECT Id FROM Games WHERE Name = @GameName)
--		 ) ug
--	WHERE ug.RoWNum % 2 != 0
--	)

--	INSERT @RtnTable SELECT @CashSum
--	RETURN
--END

--SELECT * INTO TestTable FROM  dbo.ufn_CashInUsersGames('Bali')

-- 1 - Create trigger
CREATE OR ALTER TRIGGER tr_UserGameItems ON UserGameItems INSTEAD OF INSERT
AS
BEGIN TRANSACTION

IF (EXISTS(
SELECT
    *
FROM
    inserted))
BEGIN
    INSERT INTO UserGameItems
        (UserGameId, ItemId)
    SELECT
        ug.Id,
        it.Id
    FROM
        inserted i
        JOIN Items it
        ON i.ItemId = it.Id
        JOIN UsersGames ug
        ON i.UserGameId = ug.Id
    WHERE ug.Level >= it.MinLevel
END

COMMIT
GO

-- -- 2 - Add bonus cash
-- UPDATE UsersGames
-- SET Cash += 50000
-- FROM
--     UsersGames ug
--     JOIN Users u ON ug.UserId = u.Id
--     JOIN Games-CREATE FUNCTION ufn_CashInUsersGames(@GameName VARCHAR(MAX))
--RETURNS @RtnTable TABLE
--(
--SumCash MONEY
--)
--AS
--	BEGIN
--	DECLARE @CashSum MONEY

--	SET @CashSum =  (SELECT SUM(ug.Cash) AS 'SumCash'
--	FROM (
--			SELECT Cash, GameId, ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RoWNum
--			FROM UsersGames
--			WHERE GameId = (SELECT Id FROM Games WHERE Name = @GameName)
--		 ) ug
--	WHERE ug.RoWNum % 2 != 0
--	)

--	INSERT @RtnTable SELECT @CashSum
--	RETURN
--END g ON ug.GameId = g.Id
-- WHERE g.Name = 'Bali' AND u.Username IN (
--     'baleremuda',
--     'loosenoise',
--     'inguinalself',
--     'buildingdeltoid',
--     'monoxidecos')
-- GO

-- 3 - Buy items
-- SELECT
--     Id,
--     Price
-- FROM
--     Items
-- WHERE Id BETWEEN 251 AND 299 OR Id BETWEEN 501 AND 539
INSERT INTO UserGameItems
    (UserGameId, ItemId)
SELECT
    *
FROM
    UsersGames ug
    JOIN Users u
    ON ug.UserId = u.Id
    JOIN Games g ON ug.GameId = g.Id
    JOIN UserGameItems ugi ON ug.Id = ugi.UserGameId
    JOIN Items i ON ugi.ItemId = i.Id
WHERE g.Name = 'Bali' AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')

-- -- 4 - Select users
-- SELECT
--     u.Username,
--     c.Name,
--     ug.Cash,
--     i.Name
-- FROM
--     UsersGames ug
--     JOIN Users u ON ug.UserId = u.Id
--     JOIN Games g ON ug.GameId = g.Id
--     JOIN Characters c ON ug.CharacterId = c.Id
--     JOIN UserGameItems ugi ON ug.Id = ugi.UserGameId
--     JOIN Items i ON ugi.ItemId = i.Id
-- WHERE g.Name = 'Bali'
-- ORDER BY u.Username ASC, i.Name ASC
-- GO